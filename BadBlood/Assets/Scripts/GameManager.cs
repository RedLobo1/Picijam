using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Level settings")]
    [SerializeField] public int InitialHealth = 5;
    [SerializeField] public int Currency = 0;

    [Header("Shop settings")]
    public int RegularWhiteCost = 6;
    public int TrapCost = 2;

    [Header("Managers")]
    public CurrencyManager currencyManager;  // Reference to the currency manager to add currency
    public HealthManager healthManager;  // Reference to the currency manager to add currency

    // This method is invoked when any object reaches its target

    private void Awake()
    {
        healthManager.levelHealth = InitialHealth;
    }
    public void OnObjectReachedTarget(int currencyAmount)
    {
        // Add currency to the currency manager
        currencyManager.AddCurrency(currencyAmount);
    }
    public void OnBuy(int currencyAmount)
    {
         currencyManager.DecreaseCurrency(currencyAmount);
    }
    public void OnEnemyReachedTarget(int damageAmount)
    {
        healthManager.DecreaseHealth(damageAmount);
    }

}
