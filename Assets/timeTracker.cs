using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class timeTracker : MonoBehaviour
{
    private float playTime = 0f;
    private float totalPlay;
     [SerializeField] private TextMeshProUGUI timerText;
     [SerializeField] private GameObject toggle;
    // Start is called before the first frame update
    void Start()
    {
        timerText.enabled = false;
        playTime = 0f;
        toggle = GameObject.Find("TimeShow");
    }

    // Update is called once per frame
    void Update()
    {   
        playTime += Time.deltaTime;
        timerText.text = playTime.ToString();
        PlayerPrefs.SetFloat("Time", playTime);

    }

    public void toggledatshit(bool toggleValue){
        if (toggleValue || PlayerPrefs.GetInt("toggled") == 1){
            
           timerText.enabled = true; 
           
        }
        else{
            timerText.enabled = false;
            
        }
    }
}
