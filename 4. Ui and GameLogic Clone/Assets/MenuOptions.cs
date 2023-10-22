using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOptions : MonoBehaviour
{
    public GameObject panel; // Reference to the panel you want to control (the one you want to close).

    // Method to close the panel (Continue).
    public void Continue()
    {
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }

    // Method to reset the game.
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Method to quit the game.
    public void QuitGame()
    {
        Application.Quit(); // Note: This works for standalone builds.
    }
}
