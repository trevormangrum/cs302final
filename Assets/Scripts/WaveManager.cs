using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    public int roundNum = 0;
    public Text roundText;
    GameObject RoundText;
    public GameObject[] waypoints;
    Transform t;
    public Wave[] waves;
    private int currentWave = 0;
    public int killCounter = 0;
    private bool waveInProgress;
    // Start is called before the first frame update
    void Start()
    {
        RoundText = GameObject.Find("RoundText"); 
        roundText = RoundText.GetComponent<Text>();
        t = GetComponent<Transform>();
        waveInProgress = false;
    }

    // Update is called once per frame
    void Update()
    {
        roundText.text = "Round " + roundNum.ToString() + " / " + waves.Length;
        if(currentWave != waves.Length) {
            //Update what wave needs to be accessed when a wave is over.
            if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && waveInProgress && killCounter == GetWaveSize(waves[currentWave])) {
                waveInProgress = false;
                currentWave++;
                //Add extra money for completing a round.
                GameObject mm = GameObject.FindWithTag("MoneyManager");
                mm.GetComponent<MoneyManager>().currentPlayerMoney += 200;
            } else {
                if(!waveInProgress && Input.GetKeyDown(KeyCode.Space)) {
                    //If there's no wave in progress and the user presses space,
                    //A new wave will spawn
                    roundNum++;
                    killCounter = 0;
                    waveInProgress = true;
                    StartCoroutine(SpawnWave(waves[currentWave]));
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

    int GetWaveSize(Wave wave) {
        int total = 0;
        for(int i = 0; i < wave.waveInfo.Length; i++) {
            total += wave.waveInfo[i].amount;
        }
        Debug.Log(total);
        return total;
    }



}
