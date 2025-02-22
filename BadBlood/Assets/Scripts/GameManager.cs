using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _initialHealth = 5;
    [SerializeField] private int _initialCurrency = 0;


    public CurrencyManager currencyManager;  // Reference to the currency manager to add currency
    public HealthManager healthManager;  // Reference to the currency manager to add currency

    // This method is invoked when any object reaches its target

    private void Awake()
    {
        currencyManager.currency = _initialCurrency;
        healthManager.levelHealth = _initialHealth;
    }
    public void OnObjectReachedTarget(int currencyAmount)
    {
        // Add currency to the currency manager
        currencyManager.AddCurrency(currencyAmount);
    }
    public void OnEnemyReachedTarget(int damageAmount)
    {
        healthManager.DecreaseHealth(damageAmount);
    }

}
