using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public Text playerMoneyText;
    public int currentPlayerMoney;

    public int GetCurrentMoney()
    {
        return currentPlayerMoney;
    }

    public void AddMoney(int amount)
    {
        currentPlayerMoney += amount;
        Debug.Log("Added " + amount + " to player's money! The player now has " + currentPlayerMoney);
    }

    public void RemoveMoney(int amount)
    {
        currentPlayerMoney -= amount;
        Debug.Log("Removed " + amount + " from player's money! The player now has " + currentPlayerMoney);
    }

    public void Update() 
    {
        playerMoneyText.text = currentPlayerMoney.ToString();
    }
}
