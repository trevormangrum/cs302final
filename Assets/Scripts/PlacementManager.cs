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

    public void SetMousePosition()
    {
        // Set mouse position
        hoverPos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    public void PlaceBuilding() 
    {
        // Instantiate a new tower object and call a function to buy the given tower
        GameObject newTowerObject = Instantiate(currentTowerPlacing);
        newTowerObject.transform.position = hoverPos;
        EndBuilding();
        shopManager.BuyTower(currentTowerPlacing);
        
    }
    public void StartBuilding(GameObject towerToBuild)
    {
        // Figures out which tower is being built and start building if the player has 
        // enough money to buy it
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
        // Track where the player is moving the tower that needs to be placed
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

