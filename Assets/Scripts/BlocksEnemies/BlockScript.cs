 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*BlockScript - Assigned to a tens bloc, this script give the block its value via a 
 scriptable object and means the player can interact with the script via collision.*/
public class BlockScript : MonoBehaviour
{
    public int value;

    public TextMeshProUGUI scoreTens;
    public ScriptableObjectBlock block;
    [SerializeField] private AudioSource soundEffect; 
    

   /*Consistently initialising the blocks value via the update method*/
    void Update()
    {
        value = block.value; 
    }

    /*The OnCollisionEnter2D method examines the colliding object and if its tag matches
     the player tag, the score variable from ScoreTens is increased appropriately. */
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")) {

            ScoreTens.ScoreTensCurrent += 10;
            soundEffect.Play();






        }
    }

    
}

/*<!--Number Planet - BlockScript
@Author: Julian Laffin -->*/
