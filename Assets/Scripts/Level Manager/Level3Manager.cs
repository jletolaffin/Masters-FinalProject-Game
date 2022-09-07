using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


/*The Level3Manager governs the scene containing the OrdinalEnemy's first appearance. It has
 the same functionality for dialogue and pause menus as the previous scenes. */
public class Level3Manager : MonoBehaviour
{
    private GameObject[] dialogue;

    public GameObject[] pauseMenu;
    private bool isGamePaused;

    private GameObject portal;
    
    public static bool enemiesInActive;
    public static bool levelCompleted;

    public static int enemiesCount;

    public AudioSource enemiesDefeated;
    

    

    /*The start menu resets the Place Value Number Display upon starting the scene adn initialises
     the portal, help page and pause menu, as well as a sound effect.*/
    void Start()
    {
        TotalScore.resetScore();
        portal = GameObject.FindGameObjectWithTag("PortalNextLevel");
        portal.SetActive(false);

        dialogue = GameObject.FindGameObjectsWithTag("Dialogue");

        pauseMenu = GameObject.FindGameObjectsWithTag("PauseMenu");
        foreach (GameObject p in pauseMenu)
        {

            p.SetActive(false);
        }

        enemiesDefeated = GetComponent<AudioSource>();
        

        

        

    }

    /*Upon levelCompleted being set to true from from the Ordinal Enemy, the portal object is activated
     * The update method also listens for input regarding help dialogue and the pause menu in the same
     way as the previous managers.*/
    void Update()
    {
        if (levelCompleted) {

            
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
/*<!--Number Planet - Level3Manager
@Author: Julian Laffin -->*/








