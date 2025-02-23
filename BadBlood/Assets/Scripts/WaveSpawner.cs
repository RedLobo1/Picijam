using System.Collections;
using TMPro;
using UnityEngine;

[System.Serializable]
public class SpawnWave
{
    public GameObject[] objectsToSpawn; // Array of objects to spawn
    public int spawnCount;              // Number of objects to spawn in the wave
    public float spawnInterval;         // Time between each spawn in seconds
}

public class WaveSpawner : MonoBehaviour
{
    [Header("Wave Settings")]
    public SpawnWave[] waves;           // Array of waves
    public float waveDelay = 3f;        // Delay between each wave

    private int currentWaveIndex = 0;   // To track which wave we're on
    private bool isSpawning = false;    // Flag to control spawning
    private bool waitingForNextWave = false;

    public TextMeshProUGUI textMeshProUGUI;

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    private void Update()
    {
        // Show countdown between waves
        if (waitingForNextWave)
        {
            textMeshProUGUI.text = Mathf.CeilToInt(waveDelay).ToString() + "s";
        }
    }

    // Coroutine that handles spawning waves of objects
    private IEnumerator SpawnWaves()
    {
        while (currentWaveIndex < waves.Length)
        {
            isSpawning = true;
            waitingForNextWave = false;

            SpawnWave currentWave = waves[currentWaveIndex];

            // Spawn objects in random order for the current wave
            for (int i = 0; i < currentWave.spawnCount; i++)
            {
                GameObject randomObject = GetRandomObject(currentWave.objectsToSpawn);
                SpawnObject(randomObject);
                yield return new WaitForSeconds(currentWave.spawnInterval);
            }

            // Wait before starting the next wave
            waitingForNextWave = true;

            float timer = waveDelay;
            while (timer > 0)
            {
                textMeshProUGUI.text = Mathf.CeilToInt(timer).ToString() + "s";
                timer -= Time.deltaTime;
                yield return null;
            }

            currentWaveIndex++;
        }

        // All waves finished
        textMeshProUGUI.text = "All waves complete!";
        isSpawning = false;
    }

    // Method to spawn a single object
    private void SpawnObject(GameObject objectToSpawn)
    {
        Instantiate(objectToSpawn, transform.position, Quaternion.identity);
    }

    // Method to get a random object from the array
    private GameObject GetRandomObject(GameObject[] objects)
    {
        if (objects.Length == 0) return null;
        int randomIndex = Random.Range(0, objects.Length);
        return objects[randomIndex];
    }
}
