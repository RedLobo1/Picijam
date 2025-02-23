using System.Collections;
using TMPro;
using UnityEngine;

public class CellHealthLogic : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float _maxHealth = 10f;
    [SerializeField] private float _currentHealth = 10f;


    [Header("Size Multiplier")]
    [SerializeField] private float sizeMultiplier = 1f; // Multiplier for size changes


    [Header("Timer")]
    [SerializeField] private float _timer = 0.5f;

    private TextMeshPro _enemyHealthText;

    [Header("Visuals")]
    [SerializeField] private SpriteRenderer _characterColor;
    [SerializeField] private Color _damageColor = Color.white;
    private Color _originalColor;


    private Vector3 _initialScale; // Store the original size for scaling

    void Start()
    {
        if (_enemyHealthText == null)
        {
            _enemyHealthText = GetComponentInChildren<TextMeshPro>();
        }

        _originalColor = _characterColor.color;

        _initialScale = transform.localScale; // Store the starting size
        UpdateSize(); // Set initial size according to health
    }

    void Update()
    {
        if (_currentHealth <= 0)
        {
            Kill();
        }

        if (Input.GetKeyDown(KeyCode.E)) // Damage trigger
        {
            TakeDamage(2);
        }

        if (Input.GetKeyDown(KeyCode.R)) // Heal trigger for testing
        {
            Heal(2);
        }
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth); // Prevent going below 0

        if (_enemyHealthText != null)
        {
            UpdateUI();
        }

        UpdateSize(); // Adjust size based on health
        StartCoroutine(ChangeColor());
    }

    public void Heal(float amount)
    {
        _currentHealth += amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth); // Prevent exceeding max health

        UpdateUI();
        UpdateSize(); // Adjust size after healing
    }

    private void Kill()
    {
        gameObject.SetActive(false);
    }

    private void UpdateUI()
    {
        _enemyHealthText.text = $"{_currentHealth}/{_maxHealth}";
    }

    private void UpdateSize()
    {
        float healthPercentage = _currentHealth / _maxHealth;
        // Apply the size multiplier to the scale
        transform.localScale = _initialScale * (1 + (healthPercentage - 1) * sizeMultiplier);
    }

    IEnumerator ChangeColor()
    {
        _characterColor.color = _damageColor;
        yield return new WaitForSeconds(_timer);
        _characterColor.color = _originalColor;
    }
}
