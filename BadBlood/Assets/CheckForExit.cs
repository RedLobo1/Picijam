using UnityEngine;

public class CheckForExit : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField] private int currencyAward = 1;
    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            if (collision.gameObject.CompareTag("RedCell"))
            {
                gameManager?.OnObjectReachedTarget(currencyAward);
                collision.gameObject.SetActive(false);
            }
        }
    }
}
