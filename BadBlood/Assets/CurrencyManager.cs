using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{
    public int currency = 0;        // The player's currency
    public TextMeshProUGUI currencyText;       // Reference to the UI Text component that displays the currency

    // Call this method to add currency and update the UI
    public void AddCurrency(int amount)
    {
        currency += amount;
        UpdateCurrencyUI();
    }

    // Update the currency text on the UI

    private void Start()
    {
        UpdateCurrencyUI();
    }
    private void UpdateCurrencyUI()
    {
        if (currencyText != null)
        {
            currencyText.text = "Currency: " + currency.ToString();
        }
    }
}