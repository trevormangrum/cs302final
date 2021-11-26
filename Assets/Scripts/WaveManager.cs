using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public GameObject[] waypoints;
    Transform t;
    public Wave[] waves;
    private int currentWave = 0;
    private bool waveInProgress;
    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Transform>();
        waveInProgress = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentWave != waves.Length) {
            //Update what wave needs to be accessed when a wave is over.
            if(GameObject.FindObjectOfType<Enemy>() == null && waveInProgress) {
                waveInProgress = false;
                currentWave++;
            } else {
                if(!waveInProgress && Input.GetKeyDown(KeyCode.Space)) {
                    //If there's no wave in progress and the user presses space,
                    //A new wave will spawn
                    StartCoroutine(SpawnWave(waves[currentWave]));
                    waveInProgress = true;
                }
                
            }
        }

    }

    IEnumerator SpawnWave(Wave wave) {
        for(int i = 0; i < wave.waveInfo.Length; i++) {
            for(int j = 0; j < wave.waveInfo[i].amount; j++) {
                GameObject clone = Object.Instantiate(wave.waveInfo[i].prefab, t).gameObject;
                clone.GetComponent<Enemy>().waypoints = waypoints;
                yield return new WaitForSeconds(0.4f);
            }
        }
    }



}
