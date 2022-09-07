using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
/*The LoadStatsMenu object shows the user the statistics of their gameplay, in this case
 the amount of time spent on each level. */
public class LoadStatsMenu : MonoBehaviour
{
    private GameObject LoadStatsMenuObject;
    private GameObject MainMenuObject;
    private GameObject stageTimeDisplayParent;
    private TextMeshProUGUI[] levelTimesDisplays;

    /*Initialising the objects using the awake method. Using this method as opposed to start
     could be said to be a better choice, due to awake being called before start. It also initialises
    a list of TextMeshProUGUIs that will be filled with durations of play for each scene.*/
    private void Awake() {
        LoadStatsMenuObject = this.gameObject;
        MainMenuObject = GameObject.FindGameObjectWithTag("MainMenu");
        stageTimeDisplayParent = GameObject.FindGameObjectWithTag("StageTimeDisplayParent");
        levelTimesDisplays = stageTimeDisplayParent.GetComponentsInChildren<TextMeshProUGUI>();



    
    }
    /*Using the start method, which is calle after awake, the data from the assessment object
     is retrieved and populated as text amongst the TextMeshProUGUIs in the levelTimesDisplay List.*/
    private void Start() {
        int counter = 0;
        Debug.Log("Assessment length " + Assessment.levelTimes.Count);
        foreach (TextMeshProUGUI levelTimesDisplay in levelTimesDisplays)
        {
            
            levelTimesDisplay.text = Assessment.levelTimes[counter];
            counter++;
            if (counter >= Assessment.levelTimes.Count)
            {
                break;
            }

        }

    }

   

    /*This allows the LoadStatsMenu to call the LoadAndBegin method from the DataPersistanceManager,
     which is assigned to the Load Game button on this page.*/
    public void LoadAndBeginGame()
    {

        DataPersistenceManager.instance.LoadAndBegin();

    }
    /*The back button function is assigned to the back button and allows a user to navigate
     back to the main menu from the LoadStatsMenu page.*/
    public void BackButton() {


        MainMenuObject.SetActive(true);
        this.gameObject.SetActive(false);
    }

    
}

/*<!--Number Planet - LoadStatsMenu
@Author: Julian Laffin -->*/
