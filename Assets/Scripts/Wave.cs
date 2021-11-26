using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    [System.Serializable]
    public struct EnemyData {
        [SerializeField]
        public Transform prefab;
        [SerializeField]
        public int amount;
    }

    public EnemyData[] waveInfo;
}
