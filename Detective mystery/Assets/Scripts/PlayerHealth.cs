using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f; // Changed to float to allow decimal values
    public float currentHealth; // Changed to float to allow decimal values
    public Image healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            // Handle player death
            Debug.Log("Player Dead");
        }
    }

    void UpdateHealthBar()
    {
        float healthPercent = currentHealth / maxHealth;
        Debug.Log("Updating Health Bar: " + healthPercent);
        healthBar.fillAmount = healthPercent;
    }
}
