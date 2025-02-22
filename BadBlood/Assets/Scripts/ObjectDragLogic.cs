using Unity.VisualScripting;
using UnityEngine;

public class ObjectDragLogic : MonoBehaviour
{
    public float dragRadius = 2f;   // Maximum distance to click and start dragging
    public float dragSpeedFactor = 1f; // Speed of dragging, influenced by mouse distance
    public float dragDeceleration = 1f; // Deceleration factor to gradually stop the object after release

    private Rigidbody2D rb;
    private Vector3 offset;
    private bool isDragging = false;

    void Start()
    {
        // Get the Rigidbody2D component attached to the GameObject
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Raycast from the mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;  // Ensure the raycast is in the 2D plane

        // Check if the mouse is within the drag radius and the object is clicked
        if (Input.GetMouseButtonDown(0))
        {
            float distance = Vector3.Distance(transform.position, mousePos);
            if (distance <= dragRadius)
            {
                // Calculate the offset between the object and mouse
                offset = transform.position - mousePos;
                isDragging = true;
            }
        }

        // Start dragging the object if the left mouse button is held down
        if (isDragging)
        {
            // Calculate the direction from the object to the mouse
            Vector3 direction = (mousePos + offset) - transform.position;

            // Calculate the drag speed based on the distance between the mouse and the object
            float distanceToMouse = direction.magnitude;
            float dragSpeed = distanceToMouse * dragSpeedFactor;

            // Apply the drag force to the Rigidbody2D, with the dragSpeed influencing the velocity
            rb.linearVelocity = direction.normalized * dragSpeed;

            // Optionally, you can stop the dragging when the mouse is released
            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
            }
        }
        else
        {
            // Apply gradual deceleration after releasing the mouse
            if (rb.linearVelocity.magnitude > 0)
            {
                rb.linearVelocity = Vector2.Lerp(rb.linearVelocity, Vector2.zero, dragDeceleration * Time.deltaTime);
            }
        }
        transform.rotation = Quaternion.identity;   
    }
    // Draw a circle in the Scene view to represent the drag radius
    void OnDrawGizmosSelected()
    {
        // Set the color of the Gizmo (e.g., green for the drag radius)
        Gizmos.color = Color.green;

        // Draw a wireframe circle in the Scene view (radius in world space)
        Gizmos.DrawWireSphere(transform.position, dragRadius);
    }
}
