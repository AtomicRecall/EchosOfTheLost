using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class leaderboardScript : MonoBehaviour
{
    public int score;
    public float T1;
    public float T2;
    public float T3;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("TotScor").GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("Score").ToString();
        GameObject.Find("TotTime").GetComponent<TextMeshProUGUI>().text = (T1+T2+T3).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
