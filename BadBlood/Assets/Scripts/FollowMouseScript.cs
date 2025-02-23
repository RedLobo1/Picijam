using UnityEngine;

public class FollowMouseScript : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Color originalColor;
    [SerializeField] private Color colorToChangeTo;

    [SerializeField] private GameObject originalMouse;
    [SerializeField] private GameObject trapMouse;

    public bool PlaceTrap;

    private bool isTrapActive;

    void Start()
    {
        // Store the original color of the sprite
        originalColor = spriteRenderer.color;

        // Hide the mouse cursor
        Cursor.visible = false;

        // Set initial state
        isTrapActive = false;
        originalMouse.SetActive(true);
        trapMouse.SetActive(false);
    }

    void Update()
    {
        // Make the GameObject follow the mouse position
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0; // Ensure the object stays on the same Z plane
        transform.position = mousePos;

        if (Input.GetMouseButtonDown(0)) // Left mouse button clicked
        {
            spriteRenderer.color = colorToChangeTo;

            if (PlaceTrap)
            {
                isTrapActive = !isTrapActive; // Toggle trap state
                originalMouse.SetActive(!isTrapActive);
                trapMouse.SetActive(isTrapActive);
            }
        }
        else if (Input.GetMouseButtonUp(0)) // Left mouse button released
        {
            spriteRenderer.color = originalColor;
        }
    }
}
