using UnityEngine;

public class GameManager : MonoBehaviour
{

    public CurrencyManager currencyManager;  // Reference to the currency manager to add currency

    // This method is invoked when any object reaches its target
    public void OnObjectReachedTarget(int currencyAmount)
    {
        // Add currency to the currency manager
        currencyManager.AddCurrency(currencyAmount);
    }

}
