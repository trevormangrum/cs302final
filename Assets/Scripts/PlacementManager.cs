using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: figure out how to allow the tower to be placed
public class PlacementManager : MonoBehaviour
{
    public GameObject basicTowerObject;
    private GameObject dummyPlacement;
    private Vector2 hoverPos;
    public Camera cam;
    public bool isBuilding;

    public void Start()
    {
        StartBuilding();
    }
    public void SetMousePosition()
    {
        hoverPos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    public void PlaceBuilding() 
    {
        GameObject newTowerObject = Instantiate(basicTowerObject);
        newTowerObject.transform.position = hoverPos;
        EndBuilding();
    }
    public void StartBuilding()
    {
        isBuilding = true;

        dummyPlacement = Instantiate(basicTowerObject);

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

