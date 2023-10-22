using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoClickUpgrade : MonoBehaviour
{

    public int autoClicksPerSecond;
    public int minimumClicksToUnlockUpgrade;

    private Manager manager;

    public Text priceText;

    public RotateClickers rotateClickers;


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

            autoClicksPerSecond++;
            minimumClicksToUnlockUpgrade *= 2;
            manager.ClicksTotalText.text = manager.TotalClicks.ToString("0");

            rotateClickers.SpawnObject();
            UpdateText();
        }
    }

    private void Update()
    {
        if (autoClicksPerSecond > 0)
        {
            manager.TotalClicks += autoClicksPerSecond * Time.deltaTime;

            manager.ClicksTotalText.text = manager.TotalClicks.ToString("0");
        }
    }

    private void UpdateText()
    {
        priceText.text = "Need " + minimumClicksToUnlockUpgrade.ToString() + " Clicks";
        
    }
}
