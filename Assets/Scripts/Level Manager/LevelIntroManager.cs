using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*The LevelIntroManager script managers the 'Introduction' scene, which does not contain much
 content due to it being more of a chance for players to get used to the controls and gameplay.
*/
public class LevelIntroManager : MonoBehaviour
{

    private GameObject[] helperDialogue;
    public GameObject[] pauseMenu;

    
    private bool isGamePaused;



    /*HelperDialogue and the pause menu are initialised in the same manner as in the other Level Managers.*/
    void Start()
    {
        helperDialogue = GameObject.FindGameObjectsWithTag("Dialogue");
        pauseMenu = GameObject.FindGameObjectsWithTag("PauseMenu");
        

        foreach (GameObject p in pauseMenu)
        {

            p.SetActive(false);
        }

        



    }

    /*The update method consistently checks for the user input of Z and P and activates the appropriate
     objects. If Z is pressed, help appears on the screen in the form of the Helper Character's dialogue.
    If P is pressed, the pause menu is activated.*/
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {


            foreach (GameObject go in helperDialogue)
            {
                go.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Pause Key was pressed");

            if (isGamePaused)
            {

                PlayTheGame();

            }

            else
            {
                PauseTheGame();

            }
        }





    }

    /*This method is called in update and sets all the pause menu objects to true. It also
     sets the Time.timeScale to 0, effecively freezing the game whilst the pause menu is active.*/
    public void PauseTheGame()
    {

        foreach (GameObject p in pauseMenu) { p.SetActive(true); }

        Time.timeScale = 0f;
        isGamePaused = true;

    }

    /*This method reinstates play by setting the pause menu to false and resetting the timescale
   to 1.*/
    public void PlayTheGame()
    {


        foreach (GameObject p in pauseMenu) { p.SetActive(false); }
        Time.timeScale = 1f;
        isGamePaused = false;
    }
}

/*<!--Number Planet - LevelIntroManager
@Author: Julian Laffin -->*/