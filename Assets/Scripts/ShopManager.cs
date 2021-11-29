using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Credit to ZeveonHD for a helpful tutorial to write this script
public class ShopManager : MonoBehaviour
{
    public MoneyManager moneyManager;

    public GameObject sheenPrefab;
    public GameObject darwinPrefab;
    public GameObject dickensPrefab;
    public GameObject lindberghPrefab;

    public int sheenTowerCost;
    public int darwinTowerCost;
    public int dickensTowerCost;
    public int lindberghTowerCost;

    public Text sheenCostText;
    public Text darwinCostText;
    public Text dickensCostText;
    public Text lindberghCostText;

    public int GetTowerCost(GameObject towerPrefab)
    {
        int cost = 0;

        if (towerPrefab == sheenPrefab)
        {
            cost = sheenTowerCost;
        }
        else if (towerPrefab == darwinPrefab)
        {
            cost = darwinTowerCost;
        }
        else if (towerPrefab == dickensPrefab)
        {
            cost = dickensTowerCost;
        }
        else if (towerPrefab == lindberghPrefab)
        {
            cost = lindberghTowerCost;
        }
        return cost;
    }

    public void BuyTower(GameObject towerPrefab)
    {
        moneyManager.RemoveMoney(GetTowerCost(towerPrefab));
    }

    public bool CanBuyTower(GameObject towerPrefab)
    {
        int cost = GetTowerCost(towerPrefab);

        bool canBuy = false;

        if (moneyManager.GetCurrentMoney() >= cost)
        {
            canBuy = true;
        }

        return canBuy;
    }

    public void Update() 
    {
        sheenCostText.text = "Cost: " + sheenTowerCost.ToString();
        darwinCostText.text = "Cost: " + darwinTowerCost.ToString();
        dickensCostText.text = "Cost: " + dickensTowerCost.ToString();
        lindberghCostText.text = "Cost: " + lindberghTowerCost.ToString();
    }
}
