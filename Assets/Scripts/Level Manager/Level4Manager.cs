using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*The Level4Manager accounts for the last scene in the same which contains an Ordinal Enemy
 and a Cardinal Enemy. */
public class Level4Manager : MonoBehaviour
{
    private int enemyNumber = 2;
    public static int enemiesDefeated;
    private GameObject portal;
    private GameObject[] dialogue;

    public GameObject[] pauseMenu;
    private bool isGamePaused;


    /*GameObjects are initialised including a portal to the next level (or in this case the end screen),
     Dialogue panels and the pause menu. An enemies defeated value is also set to 0. This value is incremented
    by enemy objects upon them being set inactive.*/
    void Start()
    {
        enemiesDefeated = 0;
        portal = GameObject.FindGameObjectWithTag("PortalNextLevel");
        portal.SetActive(false);

        dialogue = GameObject.FindGameObjectsWithTag("Dialogue");

        pauseMenu = GameObject.FindGameObjectsWithTag("PauseMenu");
        foreach (GameObject p in pauseMenu)
        {

            p.SetActive(false);
        }
    }

    /*Once the enemiesDefeated value is incremented to equal the enemyNumber, a portal is activated.
     This script once more checks for key input regarding dialogue and the pause menu. */
    void Update()
    {
        if (enemiesDefeated == enemyNumber) {

            portal.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Z)) {


            foreach (GameObject go in dialogue) {

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

/*<!--Number Planet - Level4Manager
@Author: Julian Laffin -->*/
