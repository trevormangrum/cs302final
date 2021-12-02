using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Credit to ZeveonHD for a helpful tutorial to write this script
//This tower class is inherited by every tower in the game
public class Tower : MonoBehaviour
{
    
    [SerializeField]protected float range;
    [SerializeField]protected float damage;
    [SerializeField]protected float attackspeed;//Time between shots (sec)
    private float nxtShot;
    public GameObject currentTarget;

    private void Start(){
        nxtShot=Time.time;
    }
    protected virtual void updateCurrTarget(){
        
        GameObject currentCurrTarget=null;
        float distance=Mathf.Infinity;
        foreach(GameObject enemy in allEnemies.enemies){
            float d2=(transform.position-enemy.transform.position).magnitude;
            if(d2<distance){
                distance=d2;
                currentCurrTarget=enemy;
            }
        }
        if(distance<=range){//if within range
            currentTarget=currentCurrTarget;
        }
        else{
            currentTarget=null;
        } 
    }
    protected virtual void fire(){
        Enemy enemyScript=currentTarget.GetComponent<Enemy>();
        enemyScript.takeDamage(damage);
    }
    protected virtual void Update(){
        updateCurrTarget();
        //fire();
        if(Time.time>=nxtShot){
            if(currentTarget!=null){
                fire();
                nxtShot=Time.time+attackspeed;
            }
        }
    }
}
