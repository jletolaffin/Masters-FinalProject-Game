using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*A Script that gives functionality and value to the numbers in scene 3, giving it a numerical value
 generated at random.*/
public class CardinalEnemy : MonoBehaviour
{
    private int enemyValue;
    private TextMeshProUGUI enemyValueText;

    /*The start method here fetches the TextMeshProUGUI in the children of the object and assigns
     the value to its text whilst converting it to a string.*/
    void Start()
    {
        enemyValue = Random.Range(1, 30);
        enemyValueText = GetComponentInChildren<TextMeshProUGUI>();
        enemyValueText.text = enemyValue.ToString();
        

    }

    
    void Update()
    {
        
    }
}

/*<!--Number Planet - CardinalEnemy
@Author: Julian Laffin -->*/
