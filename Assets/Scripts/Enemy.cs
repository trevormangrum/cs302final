using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
//using UnityEngine.Audio;
//Enemy class
public class Enemy : MonoBehaviour
{
    public float moveSpeed = 1f;
    public GameObject[] waypoints;
    Transform t;
    //private AudioSource coinSound;
    SpriteRenderer sr; 
    //Enemies changing sprites handled by: https://answers.unity.com/questions/767796/sprite-animation-dependant-on-object-direction.html
    public Sprite[] sprites;
    Vector3 target;
    private int waypointIndex;
    public float enemyHp;
    public int enemyDmg;//dmg enemy deals to gate
    public int bounty;//gold recieved for killing enemy
    public bool flying;



    private void Awake(){
        allEnemies.enemies.Add(gameObject);
        allEnemies.numEnemies++;
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
            //Update the enemy sprite based on which direction the enemy is facing.
            if (angle >= 45 && angle < 135)
                {
                    //up
                    sr.sprite = sprites[1];
                }
                else if (angle >= 135 || angle < -135)
                {
                    //left

                    sr.sprite = sprites[2];
                }
                else if (angle >= -135 && angle < -45)
                {
                    //down
                    sr.sprite = sprites[0];
                }
                else if (angle >= -45 && angle < 45)
                {
                    //right
                    sr.sprite = sprites[3];
                }
                
        } else {
            Debug.Log("HERE!");
            if(gameObject) {
                allEnemies.enemies.Remove(gameObject);
                Destroy(gameObject);
                allEnemies.numEnemies--;
                //Updates how many enemies have died/made it through in the wave manager
                //This lets the wave manager know when to start the next wave.
                GameObject wm = GameObject.FindWithTag("WaveManager");
                wm.GetComponent<WaveManager>().killCounter++;
                //Remove lives from the player if an enemy makes it to the end.
                GameObject hm = GameObject.FindWithTag("HealthManager");
                hm.GetComponent<HealthManager>().lives -= enemyDmg;
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
        //coinSound = GetComponent<AudioSource>();
        //coinSound.Play();
        allEnemies.enemies.Remove(gameObject);
        //allEnemies.speeds.Remove(moveSpeed);
        Destroy(transform.gameObject);
        allEnemies.numEnemies--;
        GameObject wm = GameObject.FindWithTag("WaveManager");
        wm.GetComponent<WaveManager>().killCounter++;
        //Give the player money for killing enemies
        GameObject mm = GameObject.FindWithTag("MoneyManager");
        mm.GetComponent<MoneyManager>().currentPlayerMoney += bounty;
    }

    private float AngleBetweenVector3(Vector3 vec1, Vector3 vec2) {
        Vector3 diff = vec2 - vec1;
        float sign = (vec2.y < vec1.y) ? -1.0f : 1.0f;
        return Vector3.Angle(Vector3.right, diff) * sign;
    }
    
    public float GetSpeed()
    {
        return moveSpeed;
    }
    public bool HasFlying(){
        return flying;
    }
    public int getDmg(){
        return enemyDmg;
    }
    public int getBounty(){
        return bounty;
    }
}
