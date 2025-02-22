using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int levelHealth = 0;        // The player's currency
    public TextMeshProUGUI levelHealthText;       // Reference to the UI Text component that displays the currency

    // Call this method to add currency and update the UI
    public void DecreaseHealth(int amount)
    {
        levelHealth -= amount;
        UpdateCurrencyUI();
    }

    // Update the currency text on the UI

    private void Start()
    {
        UpdateCurrencyUI();
    }
    private void UpdateCurrencyUI()
    {
        if (levelHealthText != null)
        {
            levelHealthText.text = levelHealth.ToString();
        }
    }
}