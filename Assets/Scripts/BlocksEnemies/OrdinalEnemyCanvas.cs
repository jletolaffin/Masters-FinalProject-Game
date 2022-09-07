using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*A script given to the three canvases that are behind the number values assigned to the OrdinalEnemy.*/
public class OrdinalEnemyCanvas : MonoBehaviour
{
    private TextMeshProUGUI numberText;
    private int number;
    private AudioSource hitNumber;
    
    /*Initialising a sound effect from attached components.*/
    void Start()
    {

        hitNumber = GetComponent<AudioSource>();

    }

    /*Initialising the text values of the TextMeshProUGUI in the children of each canvas, parsing an
     int to do so. */
    void Update()
    {
        numberText = GetComponentInChildren<TextMeshProUGUI>();
        int.TryParse(numberText.text.ToString(), out number);
    }

    /*This collision method checks the numbersSoFar list present in the OrdinalEnemy script and makes it so that if the player accidentally hits the same number twice,
    they don't have to start again. If the number is not yet in the list, it is added to the list. */
    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player")) { 
             
            if (!OrdinalEnemy.numbersSoFar.Contains(number))
            {
                OrdinalEnemy.numbersSoFar.Add(number);
                Debug.Log("Collision took place" + number.ToString());
                hitNumber.Play();
                

            }
            
        }
    }

    /*<!--Number Planet - OrdinalEnemyCanvas
@Author: Julian Laffin -->*/
}
