using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockingTrigger : MonoBehaviour
{
    public double time = 0f;
    [SerializeField] BoxCollider2D boxcoll;
    private bool movedown = false;
    [SerializeField] GameObject finalGhost;
    // Start is called before the first frame update
    void Start()
    {
        if (finalGhost == null){
            finalGhost = GameObject.FindGameObjectWithTag("finalGhost");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (movedown)
        {
            finalGhost.transform.position += Vector3.down * .2f * Time.deltaTime;
        }
    }
    void OnTriggerExit2D(Collider2D other){

        if(other.gameObject.tag == "Player"){
            boxcoll.isTrigger = !boxcoll.isTrigger;
            foreach (GameObject ghost in GameObject.FindGameObjectsWithTag("MovingGhost")){
                Destroy(ghost);
            }
            movedown = true;

        }
    }
}
