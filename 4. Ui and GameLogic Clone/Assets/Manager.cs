using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public Text ClicksTotalText;

    public float TotalClicks;

    public static Manager instance;

    public BonusClickUpgrade bonusClickUpgrade;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void AddClicks()
    {
        TotalClicks++;
        if (bonusClickUpgrade.upgradeLevel > 0)
        {
            bonusClickUpgrade.Clicked();
        }

        ClicksTotalText.text = TotalClicks.ToString("0");

        AudioManager.instance.Play("Water");
    }
    
}
