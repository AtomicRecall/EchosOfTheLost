using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAnimatorScript : MonoBehaviour
{
    public TMP_Text InstructionText;
    public float fadeTime;
    public bool shouldRun = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InstructionText.ForceMeshUpdate();
        var textInfo = InstructionText.textInfo;
        if (shouldRun){
            FadeAway(InstructionText);
        }

    }

    
    void FadeAway(TMP_Text textt){
            if (fadeTime > 0){
                fadeTime -= Time.deltaTime;
                textt.color = new Color(InstructionText.color.r, InstructionText.color.g, InstructionText.color.b, fadeTime);
            }
    }
    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("MovingGhost")){
                shouldRun = true;
            }
    }
    
}
