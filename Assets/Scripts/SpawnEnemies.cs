using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public Transform[] prefabs;
    public GameObject[] waypoints;
    Transform t;
    // Start is called before the first frame update
    void Start()
    {
       t = GetComponent<Transform>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            int carlToSpawn = Random.Range(0, prefabs.Length);
            GameObject clone = Object.Instantiate(prefabs[carlToSpawn], t).gameObject;
            clone.GetComponent<Enemy>().waypoints = waypoints;
        }
    }
}
