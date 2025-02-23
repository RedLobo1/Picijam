using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{
    public GameManager gameManager;   // The player's currency
    public TextMeshProUGUI currencyText;       // Reference to the UI Text component that displays the currency

    // Call this method to add currency and update the UI
    public void AddCurrency(int amount)
    {
        gameManager.Currency += amount;
        UpdateCurrencyUI();
    }
    public void DecreaseCurrency(int amount)
    {
        gameManager.Currency -= amount;
        UpdateCurrencyUI();
    }

    // Update the currency text on the UI

    private void Start()
    {
        gameManager = GetComponentInParent<GameManager>();
        UpdateCurrencyUI();
    }
    private void UpdateCurrencyUI()
    {
        if (currencyText != null)
        {
            currencyText.text = gameManager.Currency.ToString();
        }
    }
}