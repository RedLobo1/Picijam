using System.Collections;
using UnityEngine;

[System.Serializable]
public class SpawnWave
{
    public GameObject objectToSpawn;  // The object to spawn
    public int spawnCount;            // Number of objects to spawn in the wave
    public float spawnInterval;       // Time between each spawn in seconds
}

public class WaveSpawner : MonoBehaviour
{
    [Header("Wave Settings")]
    public SpawnWave[] waves;         // Array of waves
    public float waveDelay = 3f;      // Delay between each wave

    private int currentWaveIndex = 0; // To track which wave we're on
    private bool isSpawning = false;  // Flag to control spawning

    void Start()
    {
        // Start the spawning process
        StartCoroutine(SpawnWaves());
    }

    // Coroutine that handles spawning waves of objects
    private IEnumerator SpawnWaves()
    {
        while (currentWaveIndex < waves.Length)
        {
            SpawnWave currentWave = waves[currentWaveIndex];

            // Spawn objects for the current wave
            for (int i = 0; i < currentWave.spawnCount; i++)
            {
                SpawnObject(currentWave.objectToSpawn);
                yield return new WaitForSeconds(currentWave.spawnInterval);
            }

            // Wait before starting the next wave
            yield return new WaitForSeconds(waveDelay);

            currentWaveIndex++;
        }
    }

    // Method to spawn a single object
    private void SpawnObject(GameObject objectToSpawn)
    {
        // Spawn the object at the spawner's position (or adjust as needed)
        Instantiate(objectToSpawn, transform.position, Quaternion.identity);
    }
}
