using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: figure out how to allow the tower to be placed
public class PlacementManager : MonoBehaviour
{
    public GameObject basicTowerObject;
    private GameObject dummyPlacement;
    private GameObject hoverTile;
    public Camera cam;
    public Vector2 GetMousePosition()
    {
        return cam.ScreenToWorldPoint(Input.mousePosition);
    }
/*
    public GameObject GetCurrentHoverTile()
    {
        Vector2 mousePosition = GetMousePosition();
        RaycastHit2D hit = Physics2D.Raycast(mousePosition,new Vector2(0,0),0.1f, mask, -100, 100);

        if (hit.collider != null)
        {
        
        }
    }
*/   
    public void Update()
    {

    }
}
