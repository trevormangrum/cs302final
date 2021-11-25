using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    private int currentPlayerMoney;
    public int starterMoney;
    public Enemy enemy;

    public void Start() 
    {
        currentPlayerMoney = starterMoney;
    }

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
}
