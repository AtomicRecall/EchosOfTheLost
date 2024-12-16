using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finalGhost : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    private int timesShot = 0;
    private float mouse1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate(){

    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
            SceneManager.LoadScene("CutsceneBad");
        }
        else if(other.gameObject.tag == "pin"){
            timesShot++;
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);
        }
        if(timesShot >= 5){
            SceneManager.LoadScene("WIN");
        }
    }
}
