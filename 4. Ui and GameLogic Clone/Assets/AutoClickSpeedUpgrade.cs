using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AutoClickSpeedUpgrade : MonoBehaviour
{

    public int hasteMultiplier;
    public int minimumClicksToUnlockUpgrade;

    public AutoClickUpgrade autoClickUpgrade;

    private Manager manager;

    public Text priceText;

    private float extraClicksFromHaste;


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

            hasteMultiplier++;
            minimumClicksToUnlockUpgrade *= 2;
            manager.ClicksTotalText.text = manager.TotalClicks.ToString("0");
            UpdateText();
        }
    }

    private void Update()
    {
        if (autoClickUpgrade.autoClicksPerSecond > 0)
        {
            extraClicksFromHaste = Mathf.Round(autoClickUpgrade.autoClicksPerSecond * (hasteMultiplier * 0.1f));

            manager.TotalClicks += extraClicksFromHaste * Time.deltaTime;

            manager.ClicksTotalText.text = manager.TotalClicks.ToString("0");
        }
    }

    private void UpdateText()
    {
        priceText.text = "Need " + minimumClicksToUnlockUpgrade.ToString() + " Clicks";

    }
}
