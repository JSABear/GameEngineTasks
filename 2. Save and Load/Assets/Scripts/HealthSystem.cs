using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;




    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            // Handle character death here, e.g., disable the character, show a game over screen, etc.
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthUI();
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public void SetCurrentHealth(int newHealth)
    {
        currentHealth = Mathf.Clamp(newHealth, 0, maxHealth);
        UpdateHealthUI();
    }

    public void UpdateHealthUI()
    {
        Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>(); // Replace "Canvas" with the actual name of your Canvas

        if (canvas != null)
        {
            // Search for the "HealthText" GameObject within the Canvas
            Transform healthTextTransform = canvas.transform.Find("HealthText");

            if (healthTextTransform != null)
            {
                Text healthText = healthTextTransform.GetComponent<Text>();

                if (healthText != null)
                {
                    healthText.text = "Health: " + currentHealth + "/" + maxHealth;
                }
                else
                {
                    Debug.LogWarning("Health Text component not found on the 'HealthText' GameObject.");
                }
            }
            else
            {
                Debug.LogWarning("HealthText GameObject not found under the Canvas.");
            }
        }
        else
        {
            Debug.LogWarning("Canvas not found or is null.");
        }
    }
}