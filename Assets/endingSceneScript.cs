using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endingSceneScript : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!(audioSource.isPlaying)){
            SceneManager.LoadScene("WIN");
        }

    }
}
