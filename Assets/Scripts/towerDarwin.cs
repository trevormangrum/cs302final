using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Inherits Tower
//This tower targets the furthest along enemy with the lowest HP within it's range
public class towerDarwin : Tower
{
    public Transform pivot;
    public Transform barrel;
    public GameObject bullet;
    protected override void fire()
    {
        base.fire();
        GameObject newBullet = Instantiate(bullet,barrel.position,pivot.rotation);
    }
    protected override void updateCurrTarget(){
        float distance;
        foreach(GameObject enemy in allEnemies.enemies){
            Debug.Log("in darwin loop");
            Enemy enemyScript=enemy.GetComponent<Enemy>();
            distance=(transform.position-enemy.transform.position).magnitude;
            if((distance<=range) && (!enemyScript.HasFlying())  ){//within range and not flying
                if(currentTarget==null){
                    currentTarget=enemy;
                    break;
                }
                Enemy targetScript=currentTarget.GetComponent<Enemy>();
                if(enemyScript.getDmg()>targetScript.getDmg()){
                    currentTarget=enemy;
                }
            }
            else{
                currentTarget=null;
            }
        }
    }
}
