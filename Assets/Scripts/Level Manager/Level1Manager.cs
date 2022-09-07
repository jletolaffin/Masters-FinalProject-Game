using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*The Level1Manager script is a level manager script that has been catered for scene 1. It 
 monitors the dialogue panels and pause menu activity in the scene. */
public class Level1Manager : MonoBehaviour
{
    private GameObject[] dialogue;
    public float levelTimer;

    public GameObject[] pauseMenu;
    private bool isGamePaused;

    public GameObject[] helpPage;
    // Start is called before the first frame update
    void Start()
    {
        dialogue = GameObject.FindGameObjectsWithTag("Dialogue");
        levelTimer = Time.deltaTime;

        pauseMenu = GameObject.FindGameObjectsWithTag("PauseMenu");
        foreach (GameObject p in pauseMenu)
        {

            p.SetActive(false);
        }

        helpPage = GameObject.FindGameObjectsWithTag("HelpPage");

        foreach (GameObject p in helpPage) {

            p.SetActive(false);
        }
    }

    /*This update method is detecting user input using if statements and reacting appropriate.
     It is listening for input from the Z and P keys and setting dialogue boxes (for Z), and the
    pause menu (for P) to true when those keys are pressed. */
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z)) {

            foreach (GameObject go in dialogue) {

                go.SetActive(true);
            }
        }

        levelTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.P))//Depending on whether isGamePaused is true or not,
            //either PlayTheGame or PauseTheGame methods are called. 
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

/*<!--Number Planet - Level1Manager
@Author: Julian Laffin -->*/



