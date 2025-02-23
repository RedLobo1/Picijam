using TMPro;
using UnityEngine;

public class BuyCell : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] private GameObject Spawner;
    [SerializeField] private GameObject SpawnObject;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;

    private FollowMouseScript _followMouse;

    public enum Names
    {
        WhiteRegular,
        Trap,
        None
    }

    [SerializeField] private Names selectName;

    void Start()
    {
        _followMouse = FindAnyObjectByType<FollowMouseScript>();
        gameManager = FindFirstObjectByType<GameManager>();
        textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();

        if(selectName == Names.WhiteRegular)
        {
            textMeshProUGUI.text = $"COST: {gameManager.RegularWhiteCost.ToString()} CELLS";
        }
        else          
        {
            textMeshProUGUI.text = $"COST: {gameManager.TrapCost.ToString()} CELLS";
        }

    }

    public void BuyCellMethod()
    {
        if (gameManager.Currency >= gameManager.RegularWhiteCost)
        {
            gameManager.OnBuy(gameManager.RegularWhiteCost);
            Instantiate(SpawnObject, Spawner.transform.position, Quaternion.identity);
        }

    }

    public void BuyTrap()
    {
        if (gameManager.Currency >= gameManager.TrapCost)
        {
            gameManager.OnBuy(gameManager.TrapCost);
            Instantiate(SpawnObject, Spawner.transform.position, Quaternion.identity);
        }

    }
}
