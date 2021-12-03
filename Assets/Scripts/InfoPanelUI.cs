using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoPanelUI : MonoBehaviour
{
    public bool isOpen;
    public GameObject infoPanelUI;
    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
    }

    public void OpenMenu()
    {
        // Allows info panels to be open and closed 
        if (!isOpen) {
            infoPanelUI.SetActive(true);
            isOpen = true;
        }
        else {
            infoPanelUI.SetActive(false);
            isOpen = false;
        }
    }
}
