using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/*The MainMenu object has a variety of functionality and this script contains functions which
 have been assigned to the buttons available on the main menu.*/
public class MainMenu : MonoBehaviour
{

    
    private GameObject MainMenuPanel;
    private GameObject LoadStatsMenu;
    private GameObject[] helpPage;


    /*Initialising the game menu objects and setting the load page and help page to false
     so the main menu is displayed. */
    private void Awake()
    {
        
        MainMenuPanel = this.gameObject;
        LoadStatsMenu = GameObject.FindGameObjectWithTag("LoadStatsMenu");
        helpPage = GameObject.FindGameObjectsWithTag("HelpPage");

        LoadStatsMenu.SetActive(false);

        foreach (GameObject go in helpPage) {
            go.SetActive(false);
        }
        
    }
    /*When the new game button is clicked, the NewGame method from the DataPersistanceManager
     is called and the Introduction scene is loaded for the user to begin playing.*/
    public void OnNewGameClicked() {

        Debug.Log("New Game Clicked");
        DataPersistenceManager.instance.NewGame();
        SceneManager.LoadSceneAsync("Introduction");

    }

    /*This method allows the DataPersistanceManager LoadGame method to be accessed
     and also prints the assessment data retrieved to the console. It then sets the 
    LoadStatsMenu game object to true.*/
    public void OnLoadGameClicked() {

        Debug.Log("Load Game Clicked");
        Debug.Log("Assessment amount" + Assessment.levelTimes.Count);
        foreach (string s in Assessment.levelTimes)
        {

            Debug.Log("Assessment Data " + s);
        }
        DataPersistenceManager.instance.LoadGame();
        LoadStatsMenu.SetActive(true);

        MainMenuPanel.SetActive(false);

    }

    /*This has been assigned to the help button and activates it to be displayed for the user.*/
    public void OnHelpClicked() {

        foreach (GameObject go in helpPage)
        {
            go.SetActive(true);
        }
    }

    /*A method assigned to an exit button so the user can quit the game. */
    public void OnExitClicked() {
        
    
        Application.Quit();

    }

    
}

/*<!--Number Planet - MainMenu
@Author: Julian Laffin -->*/
