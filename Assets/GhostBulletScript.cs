using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBulletScript : MonoBehaviour
{
    public GameObject[] MovingGhosts;
    int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
       // Debug.Log("fart fart");
        //if (MovingGhosts == null){
            MovingGhosts = GameObject.FindGameObjectsWithTag("MovingGhost");
        //}
    }

    // Update is called once per frame
    void Update()
    {
        counter++;
    }

    void FixedUpdate(){
        if (counter >= 1500){
            counter = 0;
            foreach(GameObject moveghost in MovingGhosts)
                Instantiate(gameObject, moveghost.transform.position, moveghost.transform.rotation);

            }
    }
    private void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "BottomGround"){
            Destroy(gameObject);
        }
        if (other.tag == "Player"){
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().DecreaseHealth(1);
            Destroy(gameObject);
        }
    }
}
