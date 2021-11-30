using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Credit to ZeveonHD for a helpful tutorial to write this script
public class PlacementManager : MonoBehaviour
{
    public ShopManager shopManager;
    public GameObject basicTowerObject;
    private GameObject currentTowerPlacing;
    private GameObject dummyPlacement;
    private Vector2 hoverPos;
    public Camera cam;
    public bool isBuilding;

    public void Start()
    {
    }

    public bool isBetween(double small, double big, double num)
    {
        if (num > small && num < big)
            return true;
        else 
            return false;
    }
    public void SetMousePosition()
    {
        hoverPos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    public void PlaceBuilding() 
    {
        /*
        if (isBetween(15.7, 25.3, hoverPos.x) && isBetween(-.3, 1.3, hoverPos.y)) Debug.Log("Cannot place tower");
        else if (isBetween(15.7, 17.2, hoverPos.x) && isBetween(-.3, 14.1, hoverPos.y)) Debug.Log("Cannot place tower");
        else if (isBetween(5.6, 15.7, hoverPos.x) && isBetween(12.7, 14.1, hoverPos.y)) Debug.Log("Cannot place tower");
        else if (isBetween(5.6, 7.2, hoverPos.x) && isBetween(7.1, 14.1, hoverPos.y)) Debug.Log("Cannot place tower");
        else if (isBetween(5.6, 11.3, hoverPos.x) && isBetween(7.1, 8.3, hoverPos.y)) Debug.Log("Cannot place tower");
        else if (isBetween(9.7, 11.3, hoverPos.x) && isBetween(-.3, 8.3, hoverPos.y)) Debug.Log("Cannot place tower");
        else if (isBetween(2, 11.3, hoverPos.x) && isBetween(-.3, 1.3, hoverPos.y)) Debug.Log("Cannot place tower");
        else if (hoverPos.x > 25.3 || hoverPos.x < 2) Debug.Log("Cannot place tower");
        else 
        {
            */
            GameObject newTowerObject = Instantiate(currentTowerPlacing);
            newTowerObject.transform.position = hoverPos;
            EndBuilding();
            shopManager.BuyTower(currentTowerPlacing);
       // }
        
    }
    public void StartBuilding(GameObject towerToBuild)
    {
        currentTowerPlacing=towerToBuild;
        if (shopManager.CanBuyTower(currentTowerPlacing) == true)
        {
            isBuilding = true;
            currentTowerPlacing = towerToBuild;
            dummyPlacement = Instantiate(currentTowerPlacing);

            if (dummyPlacement.GetComponent<Tower>() != null)
            {
                Destroy(dummyPlacement.GetComponent<Tower>());
            }

            if (dummyPlacement.GetComponent<BarrelRotation>() != null)
            {
                Destroy(dummyPlacement.GetComponent<BarrelRotation>());
            }
        }
        else 
        {    
            //Destroy(currentTowerPlacing);
            Debug.Log("Not enough money. Cannot buy tower");
        }
        
    }

    public void EndBuilding()
    {
        isBuilding = false;
        if (dummyPlacement != null)
        {
            Destroy(dummyPlacement);
        }
    }
 
    public void Update()
    {
        SetMousePosition();
        if (isBuilding)
        {
            if (dummyPlacement != null)
            {
                if (hoverPos != null)
                {
                    dummyPlacement.transform.position = hoverPos;
                }  
            }
            if (Input.GetButtonDown("Fire1"))
            {
                PlaceBuilding();
            }
        }
    }
}

