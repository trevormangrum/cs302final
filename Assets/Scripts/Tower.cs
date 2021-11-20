using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Credit to ZeveonHD for a helpful tutorial to write this script
public class Tower : MonoBehaviour
{
    
    [SerializeField]private float range;
    [SerializeField]private float damage;
    [SerializeField]private float attackspeed;//Time between shots (sec)
    private float nxtShot;
    private GameObject currentTarget;


    private void Start(){
        nxtShot=Time.time;
    }
    private void updateNearestEnemy(){
        GameObject currentNearestEnemy=null;
        float distance=Mathf.Infinity;
        foreach(GameObject enemy in allEnemies.enemies){
            float d2=(transform.position-enemy.transform.position).magnitude;
            if(d2<distance){
                distance=d2;
                currentNearestEnemy=enemy;
            }
        }
        if(distance<=range){//if within range
            currentTarget=currentNearestEnemy;
        }
        else{
            currentTarget=null;
        }
    }
    private void fire(){
        Enemy enemyScript=currentTarget.GetComponent<Enemy>();
        enemyScript.takeDamage(damage);
    }
    private void Update(){
        updateNearestEnemy();
        if(Time.time>=nxtShot){
            if(currentTarget!=null){
                fire();
                nxtShot=Time.time+attackspeed;
            }
        }
    }
}
