using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

/*This Level manager script is significantly more complicated than the others, in that 
 it is managing rounds of play. In this scene, the user has to make three numbers using three
different sets of blocks. Depending on the playerProgress variable, different rounds of play
are initiated.*/
public class Level2Manager : MonoBehaviour
{
    private GameObject[] dialogue;

    public GameObject[] pauseMenu;
    private bool isGamePaused;
    public GameObject[] helpPage;


    private GameObject[] screwsCollectibles;
    private GameObject[] batteryCollectibles;
    private GameObject[] juiceCollectibles;

    private GameObject portalNextLevel;

    private bool batteries;
    private bool screws;
    private bool juices;

    [SerializeField] private TextMeshProUGUI totalScore;
    [SerializeField] private AudioSource portalAppears;
    private string totalScoreString;
    private int totalScoreInt;
    private static int targetNumber;

    public static int playerProgress = 0;

    private GameObject batteryScoreImage;
    private GameObject screwScoreImage;
    private GameObject juiceScoreImage;

    private GameObject targetNumberObject;

    public float levelTimer;
    
    
     
    /*Initialising gameobjects to rounds of play, as well as the images next to the
     targetNumber centred in the scene to indicate to the player the current round of play.*/
    void Start()
    {
        portalNextLevel = GameObject.FindGameObjectWithTag("PortalNextLevel");
        portalNextLevel.SetActive(false);

        dialogue = GameObject.FindGameObjectsWithTag("Dialogue");

        pauseMenu = GameObject.FindGameObjectsWithTag("PauseMenu");
        foreach (GameObject p in pauseMenu)
        {

            p.SetActive(false);
        }

        helpPage = GameObject.FindGameObjectsWithTag("HelpPage");

        foreach (GameObject p in helpPage)
        {

            p.SetActive(false);
        }

        screwsCollectibles = GameObject.FindGameObjectsWithTag("Screws");
        batteryCollectibles = GameObject.FindGameObjectsWithTag("Batteries");
        juiceCollectibles = GameObject.FindGameObjectsWithTag("JuiceCarton");

        batteryScoreImage = GameObject.FindGameObjectWithTag("BatteryScore");
        screwScoreImage = GameObject.FindGameObjectWithTag("ScrewScore");
        juiceScoreImage = GameObject.FindGameObjectWithTag("JuiceScore");

        targetNumberObject = GameObject.FindGameObjectWithTag("TargetNumber");

        screwScoreImage.SetActive(false);
        juiceScoreImage.SetActive(false);

        batteries = true;
        changeActiveObjects(batteryCollectibles, batteries);

        screws = false;
        changeActiveObjects(screwsCollectibles, screws);
        

        juices = false;
        changeActiveObjects(juiceCollectibles, juices);


        











    }

    /*The changeActiveObjects method is called constantly three times, and the bools
     assigned to it are switched to true or false depending on the playerProgress int.
    In addition, within the switch statement the appropriate scoring image is also activated.
    Finally, the update method activates a portal when the playerProgress int reaches 3 and
    accounts for dialogue and pause menus in the same manner as the Level1Manager script. */
    void Update()
    {
        bool levelComplete = false; 

        changeActiveObjects(batteryCollectibles, batteries);
        changeActiveObjects(screwsCollectibles, screws);
        changeActiveObjects(juiceCollectibles, juices);


        switch (playerProgress) {

            //switch statement based on playerProgress number.
            case 1:
                screws = true;
                batteries = false;
                juices = false;

                batteryScoreImage.SetActive(false);
                screwScoreImage.SetActive(true);

                break;

                case 2:

                screws = false;
                batteries = false;
                juices = true;
                
                screwScoreImage.SetActive(false);
                juiceScoreImage.SetActive(true);

                break;

                case 3:

                screws = false;
                batteries = false;
                juices = false;

                targetNumberObject.SetActive(false);


                
                break;
        
        }


        if (playerProgress == 3) //When playerProgress is 3, a portal is set to appear.
        {
            portalNextLevel.SetActive(true);

            levelComplete = true;
        
        }

        if (levelComplete) {//When levelComplete is true and the portal appears, a sound effect plays to
                            //provide feedback to the player.

            portalAppears.Play();
            
            levelComplete = false;
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

    /*This method sets all the GameObjects in a list to the boolean state specified, and is
     used to activate and deactivate rounds of objects in the update method.*/
    public void changeActiveObjects(GameObject[] collectibles, bool state ) { 
    
        foreach(GameObject collectible in collectibles){ 
        
            collectible.SetActive(state);
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

/*<!--Number Planet - Level2Manager
@Author: Julian Laffin -->*/
