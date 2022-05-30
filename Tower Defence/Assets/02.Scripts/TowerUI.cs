using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerUI : MonoBehaviour
{
    public static TowerUI instance;
    private void Awake()
    {
        instance = this;
    }

    public Node node;

    public Text upgradePriceText;
    public Text sellPriceText;


    private void OnDisable()
    {
        upgradePriceText.text = "";
        sellPriceText.text = "";
    }

    public void OnupgradeButton()
    {
        int nextLevel = node.tower.info.level + 1;
        if (TowerAssets.instance.TryGetTowerName(node.tower.info.type, nextLevel, out string towerName))
        {
            node.BuildTowerHere(towerName);
        }
    }
    public void OnSellButton()
    {
        node.DestroyTowerHere();
    }
}
