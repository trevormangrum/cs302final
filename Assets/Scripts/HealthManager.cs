using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public Text playerHealthText;
    public GameObject gameOverMenu;
    public int lives;
    // Start is called before the first frame update

    public void Restart()
    {
        SceneManager.LoadScene("Level1");
    }
    // Update is called once per frame
    void Update()
    {
        // Display player health on UI and if player is out of health, show game over screen
       playerHealthText.text = lives.ToString();
       if (lives <= 0)
       {
           gameOverMenu.SetActive(true);
           Time.timeScale = 0f;
       }
    }
}
