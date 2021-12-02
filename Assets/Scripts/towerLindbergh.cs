using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Shoots the closest unit, prioritizing units with flying
public class towerLindbergh : Tower//Inherits tower like all other towers
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
        bool flyingFound=false;
        foreach(GameObject enemy in allEnemies.enemies){
            Enemy enemyScript=enemy.GetComponent<Enemy>();
            distance=(transform.position-enemy.transform.position).magnitude;
            if((distance<=range) && (enemyScript.HasFlying())){//if in range and has flying
                currentTarget=enemy;
                flyingFound=true;
            }
        }
        if(!flyingFound){//if no units with flying, simply shoot the furthest along within range
            foreach(GameObject enemy in allEnemies.enemies){
                Enemy enemyScript=enemy.GetComponent<Enemy>();
                distance=(transform.position-enemy.transform.position).magnitude;
                if(distance<=range){//if in range and has flying
                    currentTarget=enemy;
                }
            }
        }
        flyingFound=false;
    }    
}
