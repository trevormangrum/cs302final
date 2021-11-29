using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class towerDickens : Tower
{
    public Transform pivot;
    public Transform barrel;
    public GameObject bullet;
    public Text rangeText;
    public Text attackText;
    protected override void fire()
    {
        base.fire();
        GameObject newBullet = Instantiate(bullet,barrel.position,pivot.rotation);
    }
    protected override void updateCurrTarget(){
        float distance;
        foreach(GameObject enemy in allEnemies.enemies){
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

    public void Update() 
    {
        rangeText.text = "Range: " + range.ToString();
        attackText.text = "Damage: " + damage.ToString();
    }
}
