using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*A script for the portals in the scene that transfer the user to the next scene. */
public class PortalToLevel : MonoBehaviour
{
    public int level = 1;//Set to 1 by default but changed in the development environment to appropriate build index.
    public GameObject endOfLevelScreen; 
    public static AudioSource appearSound;
    

    /*If the scene contains an EndLevelScreen object, this will be activated and displayed to the
     user.*/
    void Start()
    {
        appearSound = GetComponent<AudioSource>();
        endOfLevelScreen = GameObject.FindGameObjectWithTag("EndLevelScreen");

        if (endOfLevelScreen != null) { 
        
            endOfLevelScreen.SetActive(false);  
        }
    }

    
    /*Upon collision with the object, the script checks the tag of the colliding object
     and if it is the player, then a new scene is loaded. */
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {

            if (endOfLevelScreen == null)//If endOfLevelScreen is null, move onto the next scene. If not, activate it.
                SceneManager.LoadScene(level);
            TotalScore.resetScore();
        }

        else
        {
            endOfLevelScreen.SetActive(true);
        }
        
    }


}
/*<!--Number Planet - PortalToLevel
@Author: Julian Laffin -->*/

