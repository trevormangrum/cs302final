using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Text playerHealthText;
    public int lives;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
       playerHealthText.text = lives.ToString();
    }
}
