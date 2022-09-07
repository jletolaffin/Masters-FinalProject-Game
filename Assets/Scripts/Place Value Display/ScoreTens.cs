using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


/*The ScoreTens script is responsible for the Tens scoring part of the Place Value Number Display.*/
public class ScoreTens : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreTens;
    
    private GameObject[] sticks;
    public static int ScoreTensCurrent;
    
    
    /*A list of GameObjects is populated by the 10s sticks in the Place Value Number Display and 
     these are all by default set to false.*/
    void Start()
    {
        sticks = GameObject.FindGameObjectsWithTag("10Stick");

        ResetTens();
        
    }

    /*The current tens score is assigned to a string which is then shown in the TextMeshProUGUI.
     To calculate the number of sticks needed, the ScoreTensCurrent value is divided by 10
    and the for loop iterates for this amount of times, thus activating the necessary amount of sticks.
    If the score gets above 100, the tens are reset.*/
    void Update()
    {
        string currentScore = ScoreTensCurrent.ToString();
        scoreTens.text = currentScore;


        for (int i = 0; i < ScoreTensCurrent/10; i++) {
            
            
       
            sticks[i].gameObject.SetActive(true);
            

            if (ScoreTensCurrent >= 100) {
                ResetTens();

            
            }
        
        }
    }

    /*A simple reset method, setting all the 10s stick gameobjects to false and the ScoreTensCurrent
     Variable to 0. */
    public void ResetTens() {

        foreach (GameObject stick in sticks)
        {

            stick.SetActive(false);
            ScoreTensCurrent = 0;


        }

    }

    /*<!--Number Planet - ScoreTens
@Author: Julian Laffin -->*/
}
