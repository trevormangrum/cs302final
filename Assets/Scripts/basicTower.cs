using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//inherits tower
//This tower type targest the nearest enemy in its range
public class basicTower : Tower
{
    public Transform pivot;
    public Transform barrel;
    public GameObject bullet;
    protected override void fire()
    {
        
        base.fire();
        GameObject newBullet = Instantiate(bullet,barrel.position,pivot.rotation);
    }
}
