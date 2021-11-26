using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Wave 
{
    [System.Serializable]
    public struct EnemyData {
        //Prefab of enemy to spawn.
        [SerializeField]
        public Transform enemy; 
        //Amount of enemies
        [SerializeField]
        public int amount;
    }
    public List<EnemyData> enemyData;
}
