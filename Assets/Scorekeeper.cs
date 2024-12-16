using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Scorekeeper : MonoBehaviour
{

    [SerializeField] int score = 0;
    //[SerializeField] int value = 1;
    const int DEFAULT_POINTS = 1;
    [SerializeField] TextMeshProUGUI ScoreText;
    public int soulsCollected;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "SampleScene"){
            PlayerPrefs.SetInt("Score", 0);
        }
        score = PlayerPrefs.GetInt("Score");
        ScoreText.text = PlayerPrefs.GetInt("Score").ToString();
    }

    public void AddPoints(){
        AddPoints(DEFAULT_POINTS);
    }

    public void AddPoints(int value){
        score += value;
        ScoreText.text = score.ToString();
        switch (SceneManager.GetActiveScene().name){
            case "SampleScene":
                //PlayerPrefs.SetInt("Score", 0);
                if(soulsCollected >=1){
                    PlayerPrefs.SetInt("Score", score);
                    PlayerPrefs.SetString("PrevScene", SceneManager.GetActiveScene().name);
                    PlayerPrefs.SetInt("Health", 6);
                    PlayerPrefs.SetFloat("TimeLevel1", float.Parse(GameObject.FindGameObjectWithTag("time").GetComponent<TextMeshProUGUI>().text));
                    SceneManager.LoadScene("CutsceneGood");
                    soulsCollected = 0;
                }
            break;
            case "level2":
                if (soulsCollected >= 2){
                        PlayerPrefs.SetInt("Score", score);
                        PlayerPrefs.SetString("PrevScene", SceneManager.GetActiveScene().name);
                        PlayerPrefs.SetInt("Health", GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().ShowHealth());
                        PlayerPrefs.SetFloat("TimeLevel2", float.Parse(GameObject.FindGameObjectWithTag("time").GetComponent<TextMeshProUGUI>().text));
                        SceneManager.LoadScene("CutsceneGood");
                        soulsCollected = 0;
                }
            break;
            case "level3":
                if (soulsCollected >= 4){
                        PlayerPrefs.SetInt("Score", score);
                        PlayerPrefs.SetString("PrevScene", SceneManager.GetActiveScene().name);
                        PlayerPrefs.SetInt("Health", GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().ShowHealth());
                        PlayerPrefs.SetFloat("TimeLevel3", float.Parse(GameObject.FindGameObjectWithTag("time").GetComponent<TextMeshProUGUI>().text));
                        SceneManager.LoadScene("CutsceneGood"); 
                        soulsCollected = 0;
                }
            break;
            case "finalLevel":
            break;
        }
        /*
        if (SceneManager.GetActiveScene().name == "SampleScene" && score >= 3){
            SceneManager.LoadScene("CutsceneGood");
        }
        else if(SceneManager.GetActiveScene().name == "level2" && score >= 7){
            SceneManager.LoadScene("level3");
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
