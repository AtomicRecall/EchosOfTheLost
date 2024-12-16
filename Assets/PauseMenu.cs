using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public bool Paused = false;
    public GameObject PauseUI;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (Paused){
                
                Resume();
            }
            else {
                PauseUI.SetActive(true);
                Time.timeScale = 0f;
                Paused = true;
            }
        }
    }

    public void Resume(){
                PauseUI.SetActive(false);
                Time.timeScale = 1f;
                Paused = false;
    }
    public void Back2Menu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("menu");
    }

   public void Leave(){
        Application.Quit();
    }

}
