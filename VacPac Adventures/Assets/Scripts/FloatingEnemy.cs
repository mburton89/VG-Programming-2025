using UnityEngine;

public class FloatingEnemy : MonoBehaviour
{
    public float floatStrength = 0.5f;  // How high it floats
    public float floatSpeed = 2f;       // How fast it floats
    public float moveSpeed = 2f;        // How fast it follows the player

    private Vector3 startPos;
    private GameObject player;

    void Start()
    {
        startPos = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        FloatUpDown();

        if (player != null)
        {
            FollowPlayer();
        }
    }

    void FloatUpDown()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatStrength;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    void FollowPlayer()
    {
        // Move horizontally only (no Y-axis change)
        Vector3 direction = (player.transform.position - transform.position).normalized;
        direction.y = 0; // Prevent vertical movement

        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
