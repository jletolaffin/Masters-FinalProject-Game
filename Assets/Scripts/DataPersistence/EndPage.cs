using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*A simple script for the EndPage object. In a more developed version of the game, this may include
 statistics or options to visit other levels or examine rewarded rocket parts more closely,
but for the purposes of this project is kept simple. */
public class EndPage : MonoBehaviour
{
  
    
    /*A method used by the continue button to return the user to the title screen. In a full version
     of the game this would lead to the next level. */
    public void GoToTitleScreen()
    {

        SceneManager.LoadScene(0);

    }
}

/*<!--Number Planet - EndPage
@Author: Julian Laffin -->*/
