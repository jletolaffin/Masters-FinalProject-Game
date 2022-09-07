using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*This HelpPage script is used to simply provide back button functionality for when the Help
 Page is called at the game's start menu. Implementing the functions for in game Help menu
was more practical via methods set into the Pause Menu object (see PauseMenu script for more details).*/
public class HelpPage : MonoBehaviour
{
    private GameObject helpPage;
   /*Initialising the game object.*/
    void Start()
    {
        helpPage = this.gameObject;
    }

    
    /*A method assigned to the button on the title screen Help Page which closes the page, sending the
     user back to the main menu.*/
    public void CloseHelpPage() {

        helpPage.SetActive(false);
    }
}

/*<!--Number Planet - HelpPage
@Author: Julian Laffin -->*/
