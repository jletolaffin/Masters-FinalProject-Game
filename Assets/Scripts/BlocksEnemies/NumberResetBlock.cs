using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*A script assigned to the blue NumberResetBlock, allowing users to reset the score
 if it goes higher than they need it to be. */
public class NumberResetBlock : MonoBehaviour
{
    
    private AudioSource resetSound;

   



    // Start is called before the first frame update
    void Start()
    {
        resetSound = GetComponent<AudioSource>();
        
    }

    

    /*This collision method means that if the player interacts with the object,
     the resetScore method from the TotalScore script is called, setting the Place Value
    Number System to 0. */
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {

            TotalScore.resetScore();
            resetSound.Play();

            
        }
    }
}

/*<!--Number Planet - NumberResetBlock
@Author: Julian Laffin -->*/
