using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderBehaviour : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("Volume")){
            PlayerPrefs.SetFloat("Volume", 1);
            volumeSlider.value = 1;
        }
        else {
            volumeSlider.value = PlayerPrefs.GetFloat("Volume");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Change(){
        AudioListener.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
    }
}
