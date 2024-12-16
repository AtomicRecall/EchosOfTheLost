using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class audioTextController : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;   
    [SerializeField] TextMeshProUGUI textObject; 
    [SerializeField] float triggerTime = 0.5f;   
    [SerializeField] Vector3 newTextPosition;   
    public int c = 0;
    private bool hasMovedText = false;
    // Start is called before the first frame update
    void Start()
    {
        newTextPosition = new Vector2(textObject.transform.position.x, textObject.transform.position.y-9);
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource.isPlaying && audioSource.time >= triggerTime)
        {   
            MoveText();
            triggerTime+=0.2f;
            
            if(triggerTime >= 1.3 && triggerTime < 1.8){
               textObject.transform.position = new Vector2(textObject.transform.position.x, textObject.transform.position.y+10);
                MoveText(GameObject.FindGameObjectWithTag("NOT").GetComponent<TextMeshProUGUI>());
                
            }
            else if(triggerTime >= 1.8){
                textObject.transform.position = new Vector2(textObject.transform.position.x, textObject.transform.position.y+10);
                GameObject.FindGameObjectWithTag("NOT").GetComponent<TextMeshProUGUI>().transform.position = new Vector2(textObject.transform.position.x, textObject.transform.position.y+10);
                MoveText(GameObject.FindGameObjectWithTag("FINISHED").GetComponent<TextMeshProUGUI>());
            }

        }
        else if(!(audioSource.isPlaying) && (SceneManager.GetActiveScene().name == "CutsceneBad")){
            SceneManager.LoadScene("FinalLevel");
            PlayerPrefs.SetString("PrevScene",SceneManager.GetActiveScene().name);
        }
        else if(!(audioSource.isPlaying) && (SceneManager.GetActiveScene().name == "CutsceneGood")){
            string prevscene = PlayerPrefs.GetString("PrevScene");
            switch(prevscene){
                case "SampleScene":
                    SceneManager.LoadScene("level2");
                break;
                case "level2":
                    SceneManager.LoadScene("level3");
                break;
                case "level3":
                    SceneManager.LoadScene("FinalLevel");
                break;
                case "CutsceneBad":
                    SceneManager.LoadScene("DEATH");
                break;

            }
        }
        
    }
    void FixedUpdate(){

    }
     private void MoveText()
    {
   
        textObject.transform.position = newTextPosition;
        
     
        hasMovedText = true;
    }

    public void MoveText(TextMeshProUGUI textobj){
        textobj.transform.position = newTextPosition;
        
     
        hasMovedText = true;
    }
}
