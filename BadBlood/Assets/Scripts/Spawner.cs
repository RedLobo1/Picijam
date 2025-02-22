using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;  // The object to instantiate
    [SerializeField] private float spawnRadius = 5f;    // Radius in which to spawn the object
    [SerializeField] private float spawnInterval = 2f;  // Time in seconds between each spawn

    private void Start()
    {
        // Start the spawning process immediately
        StartCoroutine(SpawnObjectsAtInterval());
    }

    // Coroutine to spawn objects at a fixed interval
    private IEnumerator SpawnObjectsAtInterval()
    {
        // Infinite loop to keep spawning every 'spawnInterval' seconds
        while (true)
        {
            // Spawn the object
            SpawnObject();

            // Wait for the next spawn cycle
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // Method to spawn the object at a random location within the radius
    private void SpawnObject()
    {
        // Generate a random position within a circle around the spawner
        Vector2 randomPosition = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;

        // Instantiate the object at the random position
        Instantiate(objectToSpawn, randomPosition, Quaternion.identity);  // Using Quaternion.identity for no rotation
    }

    // This method will be called to draw the radius in the scene view
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;  // Color of the radius
        Gizmos.DrawWireSphere(transform.position, spawnRadius);  // Draw a wireframe sphere showing the radius
    }
}
