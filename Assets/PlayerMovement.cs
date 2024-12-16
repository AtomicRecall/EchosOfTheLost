using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movement;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] const int SPEED = 10;
    [SerializeField] public bool isFacingRight = true;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] float jumpForce = 500.0f;
    [SerializeField] bool isGrounded = true;
    bool RightPortal = true;
    bool LeftPortal = true;
    [SerializeField] private int Health;
    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        if (PlayerPrefs.GetInt("Health") != null){
            Health = PlayerPrefs.GetInt("Health");
        }
        
    }

    // Update is called once per frame --used for user input
    //do NOT use for physics & movement
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
            jumpPressed = true;
    }

    int counter = 0;
    bool counterQuestion = false;
    //called potentially many times per frame
    //use for physics & movement
    private void FixedUpdate()
    {   
        if (counterQuestion){
            counter++;
            if(counter > 20){
                gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                counterQuestion=false;
                counter = 0;
            }
        }
        rigid.velocity = new Vector2(SPEED * movement, rigid.velocity.y);
        if (movement < 0 && isFacingRight || movement > 0 && !isFacingRight)
            Flip();
        if (jumpPressed && isGrounded)
            Jump();
        else
            jumpPressed = false;

        
    }

    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    private void Jump()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        rigid.AddForce(new Vector2(0, jumpForce));
       // Debug.Log("jumped");
        jumpPressed = false;
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
        if (collision.gameObject.tag == "Crying_Child"){

            Destroy(GameObject.FindGameObjectWithTag("Crying_Child"));
        }
        if(collision.gameObject.tag == "finalGhost"){
            SceneManager.LoadScene("DEATH");
        }
    
        else{}
    }

    public void IncreaseHealth (int num){
        Health+=num;
    }

    public void DecreaseHealth (int num){
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        Health-=num;
        counterQuestion = true;
    }

    public int ShowHealth (){
        return Health;
    }
}
