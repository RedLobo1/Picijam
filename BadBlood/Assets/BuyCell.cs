using TMPro;
using UnityEngine;

public class BuyCell : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] private GameObject Spawner;
    [SerializeField] private GameObject SpawnObject;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;

    public enum States
    {
        WhiteCell,
        RedCell,
        BlackCell
    }

    [SerializeField] private States selectedTag;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();

        textMeshProUGUI.text = $"COST: {gameManager.RegularWhiteCost.ToString()} CELLS";
    }

    public void BuyCellMethod()
    {
        if (gameManager.Currency >= gameManager.RegularWhiteCost)
        {
            gameManager.OnBuy(gameManager.RegularWhiteCost);
            Instantiate(SpawnObject, Spawner.transform.position, Quaternion.identity);
        }

    }
}
