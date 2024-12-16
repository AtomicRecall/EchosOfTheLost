using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] GameObject pin;
    [SerializeField] GameObject capsule;
    [SerializeField] float mouse1;
    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null){
            rigid = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
            
        }
        if(pin == null){
            pin = GameObject.FindGameObjectWithTag("pin");
        }
        if (capsule == null){
            capsule = GameObject.FindGameObjectWithTag("Capsule");
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
    int c = 0;
    private void FixedUpdate(){
        
        //instead of making it a linear press ctrl to shoot, I want to make it so you have to hold your up arrow and release up arrow to shoot 
        mouse1 = Input.GetAxis("Vertical");
        if (mouse1 > 0){
 
        }
        else{
            pin.transform.position = new Vector2(12,0);
        }
    }

    public void ShootPin(){
        Debug.Log("Shooting pin");

           //pin.transform.position = new Vector2(GameObject.FindGameObjectWithTag("Capsule").transform.position.x, GameObject.FindGameObjectWithTag("Capsule").transform.position.y);

        Rigidbody2D pinRB = pin.GetComponent<Rigidbody2D>();
        if (pinRB != null){
                // Get the position at the tip of the capsule
                Vector2 tipPosition = (Vector2)(capsule.transform.position + capsule.transform.up); // Adjust 0.5f based on capsule height

                // Set the pin's position to the tip of the capsule
                pin.transform.position = new Vector3(tipPosition.x, tipPosition.y, capsule.transform.position.z*-1);

                // Get the direction the capsule is facing
                Vector2 forceDirection = capsule.transform.up;

                // Apply the force in the direction the capsule is pointing
                pinRB.AddForce((capsule.transform.up * speed), ForceMode2D.Force);
        }
    }

    private void OnCollisionEnter2D (Collision2D other){
        if(other.gameObject.tag == "BottomGround"){
            Destroy(gameObject);
        }
    }
}
