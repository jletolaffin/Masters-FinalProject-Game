using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

/*This script is responsible for the Place Value Number Display total. */
public class TotalScore : MonoBehaviour
{
    public static int totalScore;
    [SerializeField] private TextMeshProUGUI totalScoreText;
    

    
 

    /*The totalScore is found by adding the ScoreTensCurrent and the ScoreOnesCurrent values
     and then displaying this to text. */
    void Update()
    {
        totalScore = ScoreTens.ScoreTensCurrent + ScoreOnes.ScoreOnesCurrent;
        totalScoreText.text = totalScore.ToString(); 
    }

    /*This resetscore method is used elsewhere in the project and resets the entire scoring
     system, setting each value to 0 and all the scoring objects (sticks and coins) to false.*/
    public static void resetScore() {
        ScoreTens.ScoreTensCurrent = 0;
        ScoreOnes.ScoreOnesCurrent = 0;

        GameObject[] sticks = GameObject.FindGameObjectsWithTag("10Stick");
        GameObject[] ones = GameObject.FindGameObjectsWithTag("1Coin");

        foreach (GameObject stick in sticks) {

            stick.SetActive(false);
        
        }

        foreach (GameObject coin in ones) {

            coin.SetActive(false);
        
        }


        
      
    
    }

    
}

/*<!--Number Planet - TotalScore
@Author: Julian Laffin -->*/
