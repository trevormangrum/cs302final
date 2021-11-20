using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public GameObject[] waypoints;
    Transform t;
    SpriteRenderer sr;
    Vector3 target;
    private int waypointIndex;
    private float enemyHp;
    private int enemyDmg;//dmg enemy deals to gate
    private int bounty;//gold recieved for killing enemy




    private void Awake(){
        allEnemies.enemies.Add(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        waypointIndex = 0;
        t = GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
        
    }
    


    // Update is called once per frame
    void Update()
    {
        if(waypointIndex < waypoints.Length) {
            target = waypoints[waypointIndex].GetComponent<Transform>().position; 
            t.position = Vector3.MoveTowards(t.position, target, moveSpeed * Time.deltaTime); 
        } else {
            Destroy(gameObject);
        }
       if(t.position == target) {
           waypointIndex++;
       }
    }
    public void takeDamage(float dmg){//takes dmg, dies if needed
        enemyHp=enemyHp-dmg;
        if(enemyHp<=0){
            die();
        }
    }
    private void die(){//handles the enemies death
        allEnemies.enemies.Remove(gameObject);
        Destroy(transform.gameObject);
    }
}
