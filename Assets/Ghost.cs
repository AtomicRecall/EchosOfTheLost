using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
   [SerializeField] AudioSource audio;
   [SerializeField] GameObject controller;

    // Start is called before the first frame update
    void Start()
    {
      
      if (controller == null){
      //tell unity which game object im gonna be picking up
        controller = GameObject.FindGameObjectWithTag("GameController");
      }
       if (audio == null)
            audio = GetComponent<AudioSource>(); 
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 private void OnTriggerEnter2D (Collider2D collision){
    //score should be incremented
    //play sound effect
    //coin then has to be deleted
    if (collision.CompareTag("Player")){
      controller.GetComponent<Scorekeeper>().AddPoints();
      AudioSource.PlayClipAtPoint(audio.clip, transform.position);
      Destroy(gameObject);
    }
 }
}
