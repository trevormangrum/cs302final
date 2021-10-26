using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string levelScene;
    void Start() 
    {

    }
    void Update() 
    {

    }
   
    // Update is called once per frame
    public void SelectLevel() 
    {
        SceneManager.LoadScene(levelScene);
    }
}
