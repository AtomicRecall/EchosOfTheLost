using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MovingGhost : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    [SerializeField] int speed = 5;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] bool isFacingLeft = true;
    [SerializeField] float vel;
    [SerializeField] GameObject movingghost;
    [SerializeField] TextMeshProUGUI winnerText;
    [SerializeField] GameObject drop;
     public GameObject[] MovingGhosts;
    const int xMin = -8;
    const double xMax = 8.2;
    private Animator anim;
        // New fields for scaling
    [SerializeField] Vector3 targetScale = new Vector3(0.1f, 0.1f, 0.1f); // Desired scale
    [SerializeField] float scaleInterval = 2f; // Time interval in seconds
    public bool isScaledUp = false;
    // Start is called before the first frame update
    void Start()
    {
        MovingGhosts = GameObject.FindGameObjectsWithTag("MovingGhost");
        if (rigid == null){
            rigid = GetComponent<Rigidbody2D>();
            
        }
        if (audio == null)
              audio = GetComponent<AudioSource>(); 
        if (movingghost == null){
            movingghost = GameObject.FindGameObjectWithTag("MovingGhost");
            
        }
        if (winnerText == null){
            winnerText = GameObject.FindGameObjectWithTag("Canvas").GetComponent<TextMeshProUGUI>();
        }
        if (drop == null){

            drop = GameObject.FindGameObjectWithTag("Crying_Child"); 
        }
        anim = GetComponent<Animator>();
        if (SceneManager.GetActiveScene().name != "FinalLevel"){
            InvokeRepeating("ScaleGhost", 5f, scaleInterval);
        }
        else {
            
        }
                
        
    
        
            
    }  

    void Awake(){
       // drop.tag = "CloneChild";
       // Instantiate(drop, new Vector3(20f,10f,1f), Quaternion.i  dentity);
      
    }  
    int d = 0;
    void ScaleGhost()
    {
        d++;
        foreach( GameObject movingghost in MovingGhosts){
        if (movingghost != null)
        {
            if(d > 0 && (d <= 3)){
                Debug.Log("PHASE 1");
                return;
                
            }
            else if(d > 3 && d <= 6){
                Debug.Log("PHASE 2");
                speed = 10;
                movingghost.transform.localScale = new Vector3(0.085f,0.085f,0.085f);
            }
            else if (d > 6 && d < 10){
                speed = 15;
                Debug.Log("PHASE 3");
                isScaledUp = true;
                movingghost.transform.localScale = new Vector3(0.1f,0.1f,0.1f);
            }
            else{
                 Debug.Log("PHASE 4");
                 Destroy(movingghost);
                 SceneManager.LoadScene("CutsceneBad");                 
            }
        }
        }
    }

    private void FixedUpdate(){
        if (rigid.transform.position.x <= xMin){
           if(isFacingLeft){
               HEFACINGLEFT();
            }
        }
        else if(rigid.transform.position.x >= xMax){
            if(!isFacingLeft){
                rigid.velocity = new Vector2(-1 * speed, rigid.velocity.y);
                rigid.transform.Rotate(0, 180, 0);
                isFacingLeft = !isFacingLeft;
            }
        }
        else {
            if(isFacingLeft){
                rigid.velocity = new Vector2(-1 * speed , rigid.velocity.y);
            }
        }
           vel = rigid.velocity.x;
           
    }

    private void HEFACINGLEFT(){

            rigid.transform.Rotate(0, 180, 0);
            rigid.velocity = new Vector2(speed, rigid.velocity.y); 
                
            isFacingLeft = !isFacingLeft;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("ghostBullet")) return; // Ignore bullets
         //if (other.gameObject.layer == LayerMask.NameToLayer("movingGhostDetection")){
            if(SceneManager.GetActiveScene().name == "FinalLevel"){
                return;
            }

            if (other.CompareTag("pin")){
                if (isScaledUp == true){
                    GameObject.FindGameObjectWithTag("GameController").GetComponent<Scorekeeper>().AddPoints(1);
                }
                else{
                    GameObject.FindGameObjectWithTag("GameController").GetComponent<Scorekeeper>().AddPoints(3);
                }
                Instantiate(drop, gameObject.transform.position, gameObject.transform.rotation);
            //drop.transform.position = new Vector3(rigid.transform.position.x, rigid.transform.position.y, 0);

                gameObject.transform.position = new Vector3(200f,100f,0);
                audio.Play();
                
             }
            else if (other.CompareTag("Player")){
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().DecreaseHealth(1);
            }
        //}

    }

    public void WINNER(){
        if (winnerText != null)
        {
            // Move the TextMeshProUGUI component to the target position
            winnerText.rectTransform.position = new Vector3(300f, 250f, 1f);
            Destroy(GameObject.FindGameObjectWithTag("scary"));
        }
        else
        {
            
        }
    }
    
}
