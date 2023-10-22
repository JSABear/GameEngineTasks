using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneToGame : MonoBehaviour
    
{
    

    public void ChangeToGameScene()
    {
        
        SceneManager.LoadScene("Game");
        

    }
}

