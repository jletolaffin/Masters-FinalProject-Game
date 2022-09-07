using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/*A script that gives value to the Cardinal Enemy used at the end of the last game scene.*/
public class CardinalTarget : MonoBehaviour
{
    private int enemyValue;
    private TextMeshProUGUI enemyValueText;

    /*The start method assigns the enemy a random number which is higher than in previous
     rounds to attempt to provide slightly more challenge, and assigns it to the enemy's 
    Text display. */
    void Start()
    {
        enemyValue = Random.Range(21, 40);
        enemyValueText = GetComponentInChildren<TextMeshProUGUI>();
        enemyValueText.text = enemyValue.ToString();
        

    }

    /*This update method constantly checks if the score in the Place Value Display matches
     the enemy's value. If it does, the enemy is deactivated and the bool value sent to the
    CardinalEnemyDom object in order to play the sound effect.*/
    void Update()
    {
        if (TotalScore.totalScore == enemyValue) { 
        
        
            this.gameObject.SetActive(false);
            CardinalEnemyDom.enemiesInactive = true;
            

        }
    }
}

/*<!--Number Planet - CardinalTarget
@Author: Julian Laffin -->*/
