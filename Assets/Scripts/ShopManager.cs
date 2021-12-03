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

    // Function to return the cost of the tower
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

    // Function to buy the tower
    public void BuyTower(GameObject towerPrefab)
    {
        Debug.Log("Tower Bought Costs" + GetTowerCost(towerPrefab));
        moneyManager.RemoveMoney(GetTowerCost(towerPrefab));
    }

    // Function to say whather the player can buy a tower
    public bool CanBuyTower(GameObject towerPrefab)
    {
        int cost = GetTowerCost(towerPrefab);

        bool canBuy = false;
        GameObject mm = GameObject.FindWithTag("MoneyManager");
        Debug.Log("Current Money: "+  mm.GetComponent<MoneyManager>().currentPlayerMoney);
        Debug.Log("Tower Cost: "+cost);
        Debug.Log("Tower is: " + towerPrefab);
        if (moneyManager.GetCurrentMoney() >= cost)
        {
            canBuy = true;
        }

        return canBuy;
    }

    public void Update() 
    {
        // Display all the costs of the tower in the UI
        sheenCostText.text = "Cost: " + sheenTowerCost.ToString();
        darwinCostText.text = "Cost: " + darwinTowerCost.ToString();
        dickensCostText.text = "Cost: " + dickensTowerCost.ToString();
        lindberghCostText.text = "Cost: " + lindberghTowerCost.ToString();
    }
}
