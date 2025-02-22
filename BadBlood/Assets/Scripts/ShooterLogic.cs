using UnityEngine;

public class ShooterLogic : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;   // Bullet GameObject to shoot
    [SerializeField] private float shootingRadius = 5f; // Radius to detect BlackCell objects
    [SerializeField] private float cooldownTime = 1f;   // Cooldown between shots in seconds
    [SerializeField] private Transform shootingPoint;   // The point from where the bullet will be shot

    [SerializeField] private string tag;   // The point from where the bullet will be shot

    private float timeSinceLastShot = 0f;               // Time since last shot

    void Update()
    {
        // Update the cooldown timer
        timeSinceLastShot += Time.deltaTime;

        // Check for nearby BlackCell objects within the shooting radius
        Collider2D[] blackCells = Physics2D.OverlapCircleAll(transform.position, shootingRadius);

        foreach (var cell in blackCells)
        {
            if (cell.CompareTag(tag))
            {
                // If the cooldown has passed and a BlackCell is nearby, shoot a bullet
                if (timeSinceLastShot >= cooldownTime)
                {
                    Vector2 cellDirection = cell.transform.position - transform.position;
                    cellDirection.Normalize();

                    ShootBullet(cellDirection);
                    timeSinceLastShot = 0f;  // Reset the cooldown timer
                }
            }
        }
    }

    void ShootBullet(Vector2 direction)
    {
        // Instantiate a bullet at the shooting point
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
        bullet.GetComponent<Bullet>().moveDirection = direction;
    }

    // Draw the shooting radius in the editor (optional)
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootingRadius);
    }
}
