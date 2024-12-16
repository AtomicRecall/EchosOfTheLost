using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonBehaviour : MonoBehaviour
{ 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToMenu(){
        SceneManager.LoadScene("menu");
    }
    public void ToSettings(){
        SceneManager.LoadScene("options");
    }
    public void Play(){
        SceneManager.LoadScene("SampleScene");
    }
    public void Quit(){
        Application.Quit();
    }
}
