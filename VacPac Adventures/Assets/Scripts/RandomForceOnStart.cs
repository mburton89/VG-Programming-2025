using UnityEngine;

public class RandomForceOnStart : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float forceMagnitude = 10f;

    private void Awake()
    {
        // Automatically get the Rigidbody if not assigned in Inspector
        if (rb == null)
            rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        // Generate a random direction in 3D space
        Vector3 randomDirection = Random.insideUnitSphere.normalized;

        // Apply force in that direction
        rb.AddForce(randomDirection * forceMagnitude, ForceMode.Impulse);
    }

    // Optional: Visualize the direction in the Scene view
    private void OnDrawGizmosSelected()
    {
        if (rb != null)
        {
            Vector3 randomDirection = Random.insideUnitSphere.normalized;
            Gizmos.color = Color.cyan;
            Gizmos.DrawRay(transform.position, randomDirection * forceMagnitude * 0.1f);
        }
    }
}