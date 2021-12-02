using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//inherits tower
//This tower type deals 2x damage and targets random enemies

public class towerSheen : Tower
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
        GameObject newTarget=null;
        float distance=Mathf.Infinity;
        var rand=new System.Random();
        int randIndex;
        if(allEnemies.numEnemies!=0){
            while(newTarget==null){
                randIndex=rand.Next(allEnemies.numEnemies);//Random
                newTarget=allEnemies.enemies[randIndex];
                currentTarget=newTarget;
                distance=(transform.position-newTarget.transform.position).magnitude;
                if(distance<=range){//if within range
                currentTarget=newTarget;
                }
                else{
                    currentTarget=null;//if target not in range then set it to null
                }
            }
        }
        newTarget=null;
    }
}
