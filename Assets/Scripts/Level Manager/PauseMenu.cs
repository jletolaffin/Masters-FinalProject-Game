using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*The PauseMenu script contains all the functionality for the buttons included in the pause
 menu, including the back button from the help menu. */
public class PauseMenu : MonoBehaviour
{
    public GameObject[] pauseMenu;
    private GameObject[] helpPage;


    /*Initialising the PauseMenu and HelpPage lists of objects available in the scene.*/
    void Start()
    {
        pauseMenu = GameObject.FindGameObjectsWithTag("PauseMenu");
        helpPage = GameObject.FindGameObjectsWithTag("HelpPage");

        foreach (GameObject h in helpPage) {

            h.SetActive(false);
        }


    }

    /*The method assigned to the Keep Playing button in the menu. Reinstates play by
     deactivating the pause menu objects and setting the Time.timeScale to 1. */
    public void KeepPlaying() {
        foreach (GameObject p in pauseMenu)
        {

            p.SetActive(false);
        }
        Time.timeScale = 1f;

    }

    /*Assigned to the help button in the pause menu, this activates the help page object available
     in the scene.*/
    public void HelpButtonClicked() {

        foreach (GameObject p in helpPage) {

            p.SetActive(true);
        }
        
    }

    /*Assigned to the back button on the help page object, lets the user return to the pause menu
     from the help page.*/
    public void BackHelpButtonClicked() {
        foreach (GameObject p in helpPage)
        {

            p.SetActive(false);
        }

    }

    /*Set to the Save and Exit button, allows a user to return to the game's title screen, with
     saving having been enabled based on scene unloaded.*/
    public void ExitGame() {

        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        
    }

    

   

    
}
/*<!--Number Planet - PauseMenu
@Author: Julian Laffin -->*/
