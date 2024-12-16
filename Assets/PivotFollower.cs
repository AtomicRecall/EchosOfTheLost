using UnityEngine;
using UnityEngine.SceneManagement;
public class PivotFollower : MonoBehaviour
{
    public Transform capsule;        
    public float rotationSpeed = 5f; 
    private Transform target;
    private int c = 0;        
    [SerializeField] float mouse1;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] GameObject pin;
    [SerializeField] GameObject face;
    faceScript facee;
    GameObject[] movingGhostss;
    [SerializeField] GameObject Player;
    
    void Start()
    {
        // Find the GameObject with the tag "Moving Ghost" and store its transform
        GameObject movingGhost = GameObject.FindGameObjectWithTag("MovingGhost");
        movingGhostss = GameObject.FindGameObjectsWithTag("MovingGhost");
        Player = GameObject.FindGameObjectWithTag("Player");
        if (movingGhost != null)
        {
            target = movingGhost.transform;
        }
        if (rigid == null){
            rigid = GetComponent<Rigidbody2D>();
        }
        if (pin == null){
            pin = GameObject.FindGameObjectWithTag("pin");
        }
        if (face == null){
            face = GameObject.FindGameObjectWithTag("face");
        }
        if (Player == null){
            Player = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {

        }
    }

    void FixedUpdate()
    {
        facee = face.GetComponent<faceScript>();
         mouse1 = Input.GetAxis("Vertical");
         /*
        if(target == null){
                target = GameObject.FindGameObjectWithTag("finalGhost").transform;
            
        }
        */
        if (SceneManager.GetActiveScene().name == "FinalLevel"){
             target = GameObject.FindGameObjectWithTag("finalGhost").transform;
        }
        if (target != null && mouse1 > 0)
        {   
            
            rigid.transform.position = new Vector2(GameObject.FindGameObjectWithTag("Player").transform.position.x+.5f, GameObject.FindGameObjectWithTag("Player").transform.position.y+1.8f);

            //shooting logic
           //increment a time for every update
           //once it reaches that point shoot the gun
            // reset after

            if(mouse1==1){
                
                c++;

            }
            
            switch(c){
                case 10:
                    rigid.GetComponent<Transform>().localScale = new Vector3(0.1f,0.6f,1);
                    rigid.GetComponent<Renderer>().material.color = new Color(1f, 0.5f, 0f);
                    
                    break;
                case 15:
                    rigid.GetComponent<Transform>().localScale = new Vector3(0.1f,0.7f,1);
                     facee.makeSad();
                    break;
                case 25:
                    rigid.GetComponent<Transform>().localScale = new Vector3(0.1f,0.8f,1);
                     facee.makeMad();
                    break;
            }
            if(c>=50){
                    rigid.GetComponent<Renderer>().material.color = new Color(0f, 1f, 0f);
                    rigid.GetComponent<Transform>().localScale = new Vector3(0.1f,1f,1f);
                     facee.makeHappy();
                    pin.GetComponent<Bullet>().ShootPin(); 
                    c=0;
            }
            // Find which MovingGhost is closet to the player and track that one
            foreach (GameObject ghost in movingGhostss){
               if((Player.transform.position.x - ghost.transform.position.x) > (Player.transform.position.x - target.position.x)){
                target = ghost.transform;
               }
            }
            // Calculate the direction from the capsule to the target
            Vector3 direction = target.position - capsule.position;

            // Calculate the angle in degrees to rotate around the Z-axis
            float targetZRotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f; // Adjust -90 if orientation is off

            // Create a new Quaternion with the target Z rotation, leaving X and Y unchanged
            Quaternion targetRotation = Quaternion.Euler(capsule.eulerAngles.x, capsule.eulerAngles.y, targetZRotation);

            // Smoothly rotate the capsule towards the target Z rotation
            capsule.rotation = Quaternion.Lerp(capsule.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else{
            rigid.transform.position = new Vector2(12,0);
            pin.transform.position = new Vector2(12,0);
            rigid.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f);
            facee.makeNormal();
        }
    }
}