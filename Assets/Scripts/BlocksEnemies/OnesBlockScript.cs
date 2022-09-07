 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*The script given to the Ones Block, which uses a scriptable object to initialise its value. */
public class OnesBlockScript : MonoBehaviour
{
    public int value;

    [SerializeField] private AudioSource soundEffect; //The sound effect is private but assigned via the editor.
    public TextMeshProUGUI scoreOnes;
    public ScriptableObjectBlock block; 
    

    /*The update method constantly renews the block's value to that of the scriptable object. */
    void Update()
    {
        value = block.value; 
    }
    /*If the player interacts with the block, the ones score in the Place Value Number Display
     is incremented, and a sound effect plays to acknowledge the collision. */
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")) {

            ScoreOnes.ScoreOnesCurrent += value;
            soundEffect.Play();
        
        }
    }
}

/*<!--Number Planet - OnesBlockScript
@Author: Julian Laffin -->*/