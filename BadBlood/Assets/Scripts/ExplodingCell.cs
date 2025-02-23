using UnityEngine;

public class ExplodingCell : MonoBehaviour
{
    public float explosionRadius = 5f; // Radius to search for tagged objects
    public string targetTag = "Y"; // Tag to check for collision and nearby objects

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object we collided with has the target tag
        if (collision.gameObject.CompareTag(targetTag))
        {
            // Find all colliders within the explosion radius
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, explosionRadius);

            foreach (Collider hitCollider in hitColliders)
            {
                // Check if the object has the target tag
                if (hitCollider.CompareTag(targetTag))
                {
                    // Deactivate the game object

                     CellHealthLogic cellHealth = hitCollider.gameObject.GetComponent<CellHealthLogic>();
                     cellHealth.TakeDamage(1);
                }
            }
        }
    }

    // Optional: Draw the explosion radius in the editor for visualization
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
