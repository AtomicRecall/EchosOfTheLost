using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPortalScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D (Collider2D collision){
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector2(-11f,-2.3f);
    }
}
