using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public GameObject[] waypoints;
    Transform t;
    SpriteRenderer sr; 
    //Enemies changing sprites handled by: https://answers.unity.com/questions/767796/sprite-animation-dependant-on-object-direction.html
    public Sprite[] sprites;
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
            float angle = AngleBetweenVector3(t.position, target);
            if (angle >= 45 && angle < 135)
                {
                    Debug.Log("Going up!");
                    sr.sprite = sprites[1];
                }
                else if (angle >= 135 || angle < -135)
                {
                    //left
                    Debug.Log("Going left!");
                    sr.sprite = sprites[2];
                }
                else if (angle >= -135 && angle < -45)
                {
                    //down
                    Debug.Log("Going down!");
                    sr.sprite = sprites[0];
                }
                else if (angle >= -45 && angle < 45)
                {
                    //right
                    Debug.Log("Going right!");
                    sr.sprite = sprites[3];
                }
                
        } else {
            if(gameObject) {
                Destroy(gameObject);
            }
        }
       if(t.position == target) {
           waypointIndex++;
       }
    }
    public void takeDamage(float dmg){//takes dmg, dies if needed
        enemyHp=enemyHp-dmg;
        //die();
        if(enemyHp<=0){
            die();
        }
    }
    private void die(){
        //handles the enemies death
        allEnemies.enemies.Remove(gameObject);
        Destroy(transform.gameObject);
    }

    private float AngleBetweenVector3(Vector3 vec1, Vector3 vec2) {
        Vector3 diff = vec2 - vec1;
        float sign = (vec2.y < vec1.y) ? -1.0f : 1.0f;
        return Vector3.Angle(Vector3.right, diff) * sign;
    }
}
