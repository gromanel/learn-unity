using UnityEngine;

public class moveBoat : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float radius = 10f;
    public Vector3 centerPoint = Vector3.zero; // Center of the movement area
    
    private Vector3 currentDirection;
    private Vector3 startPosition;

    void Start()
    {
        // Store the starting position as the center if not set
        if (centerPoint == Vector3.zero)
        {
            centerPoint = transform.position;
        }
        
        // Initialize with a random direction
        currentDirection = new Vector3(
            Random.Range(-1f, 1f),
            0f,
            Random.Range(-1f, 1f)
        ).normalized;
        
        startPosition = transform.position;
    }

    void Update()
    {
        // Check for space bar input (works on macOS and all platforms)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeDirection();
        }
        
        // Move the boat
        transform.position += currentDirection * moveSpeed * Time.deltaTime;
        
        // Calculate distance from center
        Vector3 offsetFromCenter = transform.position - centerPoint;
        float distanceFromCenter = offsetFromCenter.magnitude;
        
        // Check if boat has exceeded the radius
        if (distanceFromCenter >= radius)
        {
            // Push the boat back inside the radius
            transform.position = centerPoint + offsetFromCenter.normalized * radius;
            
            // Reflect the direction off the border (bounce back)
            // Get the normal vector pointing from center to boat
            Vector3 normal = offsetFromCenter.normalized;
            
            // Reflect the direction vector off the normal
            currentDirection = Vector3.Reflect(currentDirection, normal);
            
            // Add some randomness to make it more natural
            currentDirection += new Vector3(
                Random.Range(-0.3f, 0.3f),
                0f,
                Random.Range(-0.3f, 0.3f)
            );
            currentDirection.y = 0f; // Keep it on the same plane
            currentDirection = currentDirection.normalized;
        }
    }
    
    // Method to change direction (called when space bar is pressed)
    void ChangeDirection()
    {
        // Generate a new random direction
        currentDirection = new Vector3(
            Random.Range(-1f, 1f),
            0f,
            Random.Range(-1f, 1f)
        ).normalized;
    }
    
    // Visualize the radius in the editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Vector3 center = centerPoint == Vector3.zero ? transform.position : centerPoint;
        Gizmos.DrawWireSphere(center, radius);
    }
}
