using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class faceScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI face;
    [SerializeField] GameObject player;
    float movementt;
    bool isMad = false;
    // Start is called before the first frame update
    void Start()
    {
        if (face == null){
            face = GameObject.FindGameObjectWithTag("face").GetComponent<TextMeshProUGUI>();
        }
        if (player == null){
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate(){ 
        PlayerMovement move = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
         movementt = Input.GetAxis("Horizontal");
         string name = SceneManager.GetActiveScene().name;
         switch ((name)){

            case "SampleScene":
                if (move.isFacingRight == false){
                    if (isMad == true){
                        //face.transform.position = new Vector2(player.transform.position.x-.1f, player.transform.position.y+.2f);
                        PutFaceInPosition(.1f-(movementt/10),.2f,false);
                    }  
                    else{
                    // face.transform.position = new Vector2(player.transform.position.x-.1f, player.transform.position.y+.1f);
                        PutFaceInPosition(.05f-(movementt/10),.1f,false);
                    }
                } 
                
                else{
                    if (isMad == true){
                    // face.transform.position = new Vector2(player.transform.position.x-.3f+(movementt/100), player.transform.position.y+.2f);
                        PutFaceInPosition(.3f-(movementt/10),.2f,true);
                    }  
                    else{
                        //face.transform.position = new Vector2(player.transform.position.x-.3f+(movementt/100), player.transform.position.y+.1f);
                        PutFaceInPosition(.3f-(movementt/10),.1f,true);
                    }
                    
                }
            break;

            case "level2":
                if (move.isFacingRight == false){
                    if (isMad == true){
                        //face.transform.position = new Vector2(player.transform.position.x-.1f, player.transform.position.y+.2f);
                        PutFaceInPosition(.1f-(movementt/10),-.15f,false);
                    }  
                    else{
                    // face.transform.position = new Vector2(player.transform.position.x-.1f, player.transform.position.y+.1f);
                        PutFaceInPosition(.1f-(movementt/10),-.25f,false);
                    }
                } 
                
                else{
                    if (isMad == true){
                    // face.transform.position = new Vector2(player.transform.position.x-.3f+(movementt/100), player.transform.position.y+.2f);
                        PutFaceInPosition(.4f-(movementt/10),-.15f,true);
                    }  
                    else{
                        //face.transform.position = new Vector2(player.transform.position.x-.3f+(movementt/100), player.transform.position.y+.1f);
                        PutFaceInPosition(.4f-(movementt/10),-.25f,true);
                    }
                    
                }
            break;

            case "level3":
                if (move.isFacingRight == false){
                    if (isMad == true){
                        //face.transform.position = new Vector2(player.transform.position.x-.1f, player.transform.position.y+.2f);
                        PutFaceInPosition(.1f-(movementt/10),-.15f,false);
                    }  
                    else{
                    // face.transform.position = new Vector2(player.transform.position.x-.1f, player.transform.position.y+.1f);
                        PutFaceInPosition(.1f-(movementt/10),-.25f,false);
                    }
                } 
                
                else{
                    if (isMad == true){
                    // face.transform.position = new Vector2(player.transform.position.x-.3f+(movementt/100), player.transform.position.y+.2f);
                        PutFaceInPosition(.4f-(movementt/10),-.15f,true);
                    }  
                    else{
                        //face.transform.position = new Vector2(player.transform.position.x-.3f+(movementt/100), player.transform.position.y+.1f);
                        PutFaceInPosition(.4f-(movementt/10),-.25f,true);
                    }
                    
                }
            break;

            case "FinalLevel":
                face.text = ":?";
                if (move.isFacingRight == false){
                    if (isMad == true){
                        //face.transform.position = new Vector2(player.transform.position.x-.1f, player.transform.position.y+.2f);
                        PutFaceInPosition(.1f,.2f,false);
                    }  
                    else{
                    // face.transform.position = new Vector2(player.transform.position.x-.1f, player.transform.position.y+.1f);
                        PutFaceInPosition(.1f,.2f,false);
                    }
                } 
                
                else{
                    if (isMad == true){
                    // face.transform.position = new Vector2(player.transform.position.x-.3f+(movementt/100), player.transform.position.y+.2f);
                        PutFaceInPosition(.3f,.2f,true);
                    }  
                    else{
                        //face.transform.position = new Vector2(player.transform.position.x-.3f+(movementt/100), player.transform.position.y+.1f);
                        PutFaceInPosition(.3f,.2f,true);
                    }
                    
                }
            break;
            default:
            break;
         }

        
    }
    public void PutFaceInPosition(float subtraction, float addition2, bool FacingRight){
        if (!FacingRight){
            face.transform.position = new Vector3(player.transform.position.x-subtraction, player.transform.position.y+addition2, 10f);
        }
        else{
            face.transform.position = new Vector3(player.transform.position.x-(subtraction), player.transform.position.y+addition2, 10f);
        }
    }
    public void makeMad(){
        isMad = true;
        face.text = ">:(";
        
    }
    public void makeSad(){
        isMad = false;
        face.text =(":(");
    }
    public void makeHappy(){
        isMad = false;
        face.text = (":D");
    }
    public void makeNormal(){
        isMad = false;
        face.text=(":)");
    }
}
