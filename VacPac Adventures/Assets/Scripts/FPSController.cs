using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    public static FPSController Instance;

    public float moveSpeed = 5.0f;
    public float mouseSensitivity = 2.0f;
    public float jumpForce = 5.0f;
    public Transform playerCamera;

    private float originSpeed;

    private CharacterController characterController;
    private float verticalRotation = 0;
    private float verticalVelocity = 0;

    // Fly Stats

    private float currentVelocity = 0;
    public float rate = 0.01f;
    public float flyLimit = 10f;
    private bool flying = false;

    public float fuelConsumptionRate = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        {
            Instance = this;
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

        // Space check

        if (Input.GetKey(KeyCode.Space))
        {
            flying = true;
        }
        else
        {
            flying = false;
            currentVelocity = 0;
        }

        // Air check
        if (characterController.isGrounded)
        {

            // Jumping

            if (Input.GetKeyDown(KeyCode.Space))
            {
                print("jump");
                verticalVelocity = jumpForce;
                moveSpeed = originSpeed;

                StartCoroutine(Flying(0.5f));
            }

            // Sprinting

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
        else
        {
            // Flying

            print("Not on ground");
            print(flying);

            if (flying == true && PlayerTemp.Instance.currentFuel > 0)
            {
                //Call Fuel Bar
                PlayerTemp.Instance.currentFuel -= fuelConsumptionRate;

                if (PlayerTemp.Instance.currentFuel < 0f)
                {
                    PlayerTemp.Instance.currentFuel = 0f;
                }
                
                float h = Input.GetAxis("Horizontal");
                float v = Input.GetAxis("Vertical");

                Vector3 move = transform.right * h + transform.forward * v;

                if (Input.GetKey(KeyCode.Space))
                {
                    print("Flying");

                    if (currentVelocity < 0)
                    {
                        currentVelocity = 0;
                    }

                    if (verticalVelocity < 0)
                    {
                        verticalVelocity = 0;
                    }

                    if (currentVelocity >= flyLimit)
                    {
                        print("Limit reached");
                        currentVelocity = flyLimit;
                    }
                    else
                    {
                        currentVelocity += rate;
                    }

                        move.y = 1;
                }
                else
                {
                    print("Release");
                    move.y = verticalVelocity;
                    verticalVelocity -= Time.deltaTime * 10.0f; // Apply gravity
                    currentVelocity = 0;
                }

                transform.GetComponent<CharacterController>().Move(move * currentVelocity * Time.deltaTime);
            }
            else
            {
                verticalVelocity -= Time.deltaTime * 10.0f; // Apply gravity
            }
        }

        characterController.Move(movement * Time.deltaTime);
    }

    private IEnumerator Flying(float timeBeforeFly)
    {
        print("Waiting");
        yield return new WaitForSeconds(timeBeforeFly);
        print("Working");

        if (Input.GetKey(KeyCode.Space)) // if holding space
        {
            print("Flying");
            flying = true;
        }
    }
}
