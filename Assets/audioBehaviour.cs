using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioBehaviour : MonoBehaviour
{

    private AudioSource audioSource;

 
    public AudioClip[] audioClips;

    // Start is called before the first frame update
    void Start()
    {
        if(audioSource == null){
            audioSource = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void PlayAudio(int clipIndex)
    {
        if (clipIndex >= 0 && clipIndex < audioClips.Length)
        {
            audioSource.clip = audioClips[clipIndex];
            audioSource.Play();
        }
        else
        {
            
        }
    }
}
