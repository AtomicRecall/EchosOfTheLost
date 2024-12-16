using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dropPickup : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] TextMeshProUGUI winnerText;
    [SerializeField] GameObject movingghost;
    public bool shouldMove = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate(){
    
    }
        private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player"){
            winnerText.rectTransform.position = new Vector3(rigid.transform.position.x, rigid.transform.position.y, 1f);
            GameObject.FindGameObjectWithTag("GameController").GetComponent<Scorekeeper>().soulsCollected+=1;
            if (movingghost.GetComponent<MovingGhost>().isScaledUp == true){
                GameObject.FindGameObjectWithTag("GameController").GetComponent<Scorekeeper>().AddPoints(1);
                Destroy(gameObject);
             }
             else{
                 GameObject.FindGameObjectWithTag("GameController").GetComponent<Scorekeeper>().AddPoints(1);
                 Destroy(gameObject);
             }
            shouldMove = true;
        }   
        else
            {}
    }
}
