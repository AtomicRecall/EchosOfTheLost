using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
    public GameObject player;
    int Health;
    // Start is called before the first frame update
    void Start()
    {
        if (player == null){
            player = GameObject.FindGameObjectWithTag("Player");
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate(){
        
        Health = player.GetComponent<PlayerMovement>().ShowHealth();
        RectTransform good = GameObject.FindGameObjectWithTag("health").GetComponent<RectTransform>();
        RectTransform bad = GameObject.Find("badhealth").GetComponent<RectTransform>();
        RectTransform med = GameObject.Find("medhealth").GetComponent<RectTransform>();

        switch(Health){
            case 6:
                good.localPosition = new Vector3(297,190,0);
                bad.localPosition = new Vector3(303,500,0);
                med.localPosition = new Vector3(303,500,0);
            break;

            case 4:
                good.localPosition = new Vector3(303,500,0);
                bad.localPosition = new Vector3(303,500,0);
                med.localPosition = new Vector3(297,190,0);
            break;

            case 2:
                good.localPosition = new Vector3(303,500,0);
                bad.localPosition = new Vector3(297,190,0);
                med.localPosition = new Vector3(303,500,0);
            break;

            case 0:
                 SceneManager.LoadScene("CutsceneBad");
            break;
        }
    
    }
}
