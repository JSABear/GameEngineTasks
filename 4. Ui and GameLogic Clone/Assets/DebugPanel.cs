using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugPanel : MonoBehaviour
{

    private Manager manager;
    public Text debugText;

    public AutoClickUpgrade autoClickUpgrade;
    public AutoClickSpeedUpgrade autoClickSpeedUpgrade;
    public BonusClickUpgrade bonusClickUpgrade;


    // Start is called before the first frame update

    void Start()
    {
        manager = Manager.instance;
        debugText.text = " Extra Clicks: " + bonusClickUpgrade.upgradeLevel + "\n Auto Clickers: " + autoClickUpgrade.autoClicksPerSecond + "\n Click haste " + autoClickSpeedUpgrade.hasteMultiplier;

    }

    // Update is called once per frame
    void Update()
    {
        debugText.text = " Extra Clicks: " + bonusClickUpgrade.upgradeLevel + "\n Auto Clickers: " + autoClickUpgrade.autoClicksPerSecond + "\n Click haste " + autoClickSpeedUpgrade.hasteMultiplier;

    }
}
