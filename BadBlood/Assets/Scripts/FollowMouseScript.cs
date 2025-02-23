using UnityEngine;

public class FollowMouseScript : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Color originalColor;


    [SerializeField] private Color colorToChangeTo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get the SpriteRenderer component attached to this GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Store the original color of the sprite
        originalColor = spriteRenderer.color;

        // Hide the mouse cursor
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Make the GameObject follow the mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0; // Ensure the object stays on the same Z plane
        transform.position = mousePos;

        // Change color based on left mouse button input
        if (Input.GetMouseButtonDown(0)) // Left mouse button clicked
        {
            spriteRenderer.color = colorToChangeTo;
        }
        else if (Input.GetMouseButtonUp(0)) // Left mouse button released
        {
            spriteRenderer.color = originalColor;
        }
    }
}
