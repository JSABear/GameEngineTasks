using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTextUpdater : MonoBehaviour
{
    public Text healthText;  // Reference to the Text object
    public HealthSystem playerHealthSystem;
    public int loadHealth;
    int currentHealth = LoadGameState.health;


    // Start is called before the first frame update
    void Start()
    {
        loadHealth = playerHealthSystem.GetCurrentHealth();
        // Initialize currentHealth with the initial health value
        currentHealth = LoadGameState.health;  // You can set this to your starting health value
        UpdateHealthText();
    }

    void Update()
    {
        loadHealth = playerHealthSystem.GetCurrentHealth();
        SetHealth(loadHealth);
        
    }

    // Function to update the health text
    void UpdateHealthText()
    {
        playerHealthSystem.SetCurrentHealth(currentHealth);
    }

    // Function to set the health data and update the text if it changes
    public void SetHealth(int newHealth)
    {
        if (newHealth != currentHealth)
        {
            Debug.Log(loadHealth);
            Debug.Log(playerHealthSystem.currentHealth);
            currentHealth = newHealth;
            playerHealthSystem.currentHealth = newHealth;
            UpdateHealthText();
            Debug.Log(playerHealthSystem.currentHealth);
        }
    }
}

