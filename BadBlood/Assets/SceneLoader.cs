using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public int SceneToLoad = 1; // The index of the scene to load
    public float delayInSeconds = 5f; // Time delay before switching scenes

    void Start()
    {
        // Start the coroutine to switch scenes after a delay
        StartCoroutine(LoadSceneAfterDelay());
    }

    private System.Collections.IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(delayInSeconds); // Wait for X seconds
        SceneManager.LoadScene(SceneToLoad); // Load the specified scene
    }
}

