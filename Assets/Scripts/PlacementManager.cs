using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: figure out how to allow the tower to be placed
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
    public void SetMousePosition()
    {
        hoverPos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    public void PlaceBuilding() 
    {
        if (shopManager.CanBuyTower(currentTowerPlacing))
        {
            GameObject newTowerObject = Instantiate(currentTowerPlacing);
            newTowerObject.transform.position = hoverPos;
            EndBuilding();
            shopManager.BuyTower(currentTowerPlacing);
        }
        else 
        {
            Debug.Log("Not enough money. Cannot buy tower");
        }
        
    }
    public void StartBuilding(GameObject towerToBuild)
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

