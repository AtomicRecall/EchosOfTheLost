using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
     int NUM_COINS = 1;
    [SerializeField] GameObject coin;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "level2"){
            NUM_COINS = 3;
        }
        else if(SceneManager.GetActiveScene().name == "level3"){
            NUM_COINS = 10;
        }
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        int xMin = -3;
        int xMax =6;

        for (int i = 0; i < NUM_COINS; i++)
        {
            Vector2 position = new Vector2(Random.Range(xMin, xMax), -4);
            Instantiate(coin, position, Quaternion.identity);
        }
    }
}
