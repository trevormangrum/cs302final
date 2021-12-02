using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This unit takes out enemies that give the most Money
public class towerDickens : Tower//Inherits tower like all other towers
{
    public Transform pivot;
    public Transform barrel;
    public GameObject bullet;
    private AudioSource shotSound;
    protected override void fire()
    {
        shotSound = GetComponent<AudioSource>();//Sound
        shotSound.Play();
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
                if(enemyScript.getBounty()>targetScript.getBounty()){
                    currentTarget=enemy;
                }
            }
            else{
                currentTarget=null;
            }
        }
    }

}
