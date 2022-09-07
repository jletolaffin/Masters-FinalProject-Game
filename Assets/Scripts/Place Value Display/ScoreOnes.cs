using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*This script controls the ones scoring section of the Place Value Number System. */
public class ScoreOnes : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreOnes;

    public GameObject[] coins; 
    public static int ScoreOnesCurrent;

    [SerializeField]private AudioSource tenComplete; 
   

    /*Upon start, a list of 'coins' or 1 counters is initialised, these being the yellow coins
     displayed in the Place Value Display. An audio sound for building a ten is also completed. */
    void Start()
    {
        coins = GameObject.FindGameObjectsWithTag("1Coin");
        foreach (GameObject coin in coins)
        {

            coin.SetActive(false);


        }

        tenComplete = GetComponent<AudioSource>();
    }

   
    /*The update method constantly sets the ScoreOnesCurrent value to the text in the TextMeshProUGUI
     assigned to the 1s in the Place Value Number Display. It also calls CoinsReset().*/
    void Update()
    {
        string currentScore = ScoreOnesCurrent.ToString();
        scoreOnes.text = currentScore;

        for (int i = 0; i < ScoreOnesCurrent; i++)
        {



            coins[i].gameObject.SetActive(true);
            

        }

        CoinsReset();



        
    }

    /*This method checks if the user has hit a ones block ten times and therefore made a ten. 
    If so, the ones coins are all set to false and the score is carried over to the 
    ScoreTens.ScoreTensCurrent variable.*/
    public void CoinsReset() {

        if (ScoreOnesCurrent >= 10)
        {

            ScoreTens.ScoreTensCurrent += ScoreOnesCurrent;

            for (int i = 0; i < ScoreOnesCurrent; i++)
            {



                coins[i].gameObject.SetActive(false);
                Debug.Log(i);
                Debug.Log("Coin Score reset.");

            }
            ScoreOnesCurrent = 0;
            tenComplete.Play();

        }


    }

    /*<!--Number Planet - ScoreOnes
@Author: Julian Laffin -->*/
}
