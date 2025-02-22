using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;   // Speed of the bullet
    [SerializeField] private float lifetime = 5f;  // Lifetime of the bullet before it is destroyed

    public Vector2 moveDirection;

    void Start()
    {

        // Destroy the bullet after a set time to prevent it from existing forever
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Move the bullet in the set direction
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Destroy the bullet on any collision
        Destroy(gameObject);
    }
}
