using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusClickUpgrade : MonoBehaviour
{

    public int upgradeLevel = 0;
    public int minimumClicksToUnlockUpgrade;

    private Manager manager;

    public Text priceText;


    private void Start()
    {
        manager = Manager.instance;
        UpdateText();
    }

    public void BuyUpgrade()
    {
        if (manager.TotalClicks >= minimumClicksToUnlockUpgrade)
        {
            manager.TotalClicks -= minimumClicksToUnlockUpgrade;

            upgradeLevel++;
            minimumClicksToUnlockUpgrade *= 2;
            manager.ClicksTotalText.text = manager.TotalClicks.ToString("0");
            UpdateText();
        }
    }


    private void UpdateText()
    {
        priceText.text = "Need " + minimumClicksToUnlockUpgrade.ToString() + " Clicks";

    }

    public void Clicked()
    {
        if (upgradeLevel > 0)
        {
            for (int i = 0; i < upgradeLevel; i++)
            {
                manager.TotalClicks++;
            }
        }
    }
}
