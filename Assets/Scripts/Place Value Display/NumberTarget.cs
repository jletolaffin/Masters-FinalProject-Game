using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*Within the level 2 scene, this script is used to assign a random target number to the 
 TextMeshProUGUI central to the screen.*/
public class NumberTarget : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI targetNumberText;
    public static int targetNumber;
    public bool totalReached;
    private AudioSource progressMusic;
    

    /*Upon start, a random number method is ran to set a random number to the text
     and progresMusic is initialised.*/
    void Start()
    {
        setRandomNumber();
        targetNumberText.text = targetNumber.ToString();
        progressMusic = GetComponent<AudioSource>();
    }

    /*The update method constantly checks if the player has built the correct number. When they have,
     the Level2Manager playerProgress count is incremented and a random number is generated once
    more to be reassigned to the text for the next round. The totalScore on the Place Value Number
    Display is also reset.*/
    void Update()
    {
        if (TotalScore.totalScore == targetNumber) {

           
            totalReached = true;
            Level2Manager.playerProgress++;


        }

        if (totalReached) { 
            setRandomNumber();
            totalReached = false;
            Debug.Log("Here is a number" + targetNumber);
            TotalScore.resetScore();
            progressMusic.Play();


        }

        targetNumberText.text = targetNumber.ToString();
        
    }

    /*A quick method that simply sets the target number to a random number between 1 and 50.*/
    public static void setRandomNumber() { 
    
        targetNumber = Random.Range(1, 50);

    
    
    
    }
    /*<!--Number Planet - NumberTarget
@Author: Julian Laffin -->*/
}
