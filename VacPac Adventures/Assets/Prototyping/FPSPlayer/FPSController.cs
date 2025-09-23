using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float mouseSensitivity = 2.0f;
    public float jumpForce = 5.0f;
    public Transform playerCamera;

    private float originSpeed;

    private CharacterController characterController;
    private float verticalRotation = 0;
    private float verticalVelocity = 0;

    private bool flying = false;

    // Start is called before the first frame update
    void Start()
    {
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            characterController = GetComponent<CharacterController>();
            originSpeed = moveSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Camera
        float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, horizontalRotation, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -90, 90);
        playerCamera.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        // Movement
        float moveForward = Input.GetAxis("Vertical") * moveSpeed;
        float moveSideways = Input.GetAxis("Horizontal") * moveSpeed;

        Vector3 movement = new Vector3(moveSideways, verticalVelocity, moveForward);
        movement = transform.rotation * movement;

        // Jumping
        if (characterController.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                print("jump");
                verticalVelocity = jumpForce;
                moveSpeed = originSpeed;

                // Flying
                float h = Input.GetAxis("Horizontal");
                float v = Input.GetAxis("Vertical");

                Vector3 move = transform.right * h + transform.forward * v;
                StartCoroutine(Flying(1f, 0, 0.5f,10,move));
            }
        }
        else
        {
            verticalVelocity -= Time.deltaTime * 10.0f; // Apply gravity
        }

        characterController.Move(movement * Time.deltaTime);

        //Sprinting

        if (characterController.isGrounded)
        {

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                print("Sprint");
                moveSpeed *= 2;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                print("No sprint");
                moveSpeed = originSpeed;
            }
        }
    }

    private IEnumerator Flying(float timeBeforeFly, float currentVelocity, float rate, int flyLimit, Vector3 move)
    {
        print("Waiting");
        yield return new WaitForSeconds(timeBeforeFly);
        print("Working");
        while (Input.GetKey(KeyCode.Space))
        {
            print("Holding up");
            move.y = 1;

            if (currentVelocity >= flyLimit)
            {
                currentVelocity = flyLimit;
                print("Stop");
            }
            else
            {
                currentVelocity += rate;
                print("Fly now");
            }
        }

        move.y = -1;
        currentVelocity = 0;
        print("Release");
        transform.GetComponent<CharacterController>().Move(move * currentVelocity * Time.deltaTime);
    }
}
