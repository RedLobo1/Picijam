using System.Collections;
using TMPro;
using UnityEngine;

public class CellHealthLogic : MonoBehaviour
{
    [Header("Health")]  // Corrected header title

    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealth;

    [Header("Timer")]  // Corrected header title

    [SerializeField] private float _timer = 0.5f;

    private TextMeshPro _enemyHealthText;

    private SpriteRenderer _characterColor;
    private Color _originalColor;

    void Start()
    {
        if(_enemyHealthText == null)
        {
            _enemyHealthText = GetComponentInChildren<TextMeshPro>();
        }
        _characterColor = GetComponent<SpriteRenderer>();
        _originalColor = _characterColor.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentHealth <= 0)
        {
            Kill();
        }

        if (Input.GetKeyDown(KeyCode.E))  // Corrected this part
        {
            TakeDamage(2);
        }
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;


        if (_enemyHealthText != null)
        {
            UpdateUI();
        }
        StartCoroutine(ChangeColor());
        //Put enemy damage logic here
    }

    public void Kill()
    {
        //PutKillLogicHere
        gameObject.SetActive(false);
    }

    private void UpdateUI()
    {
        _enemyHealthText.text = _currentHealth.ToString();
    }

    IEnumerator ChangeColor()
    {
        _characterColor.color = Color.white;
        yield return new WaitForSeconds(_timer);  // Corrected this line
        _characterColor.color = _originalColor;
    }
}
