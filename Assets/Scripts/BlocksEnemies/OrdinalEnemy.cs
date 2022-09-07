using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/*A script assigned to the OrdinalEnemy object which is a child of the OrdinalEnemyDom object. */
public class OrdinalEnemy : MonoBehaviour
{
    private GameObject[] numbersToHit;
    private List<int> numbers;
    public static List<int> numbersSoFar;
    public static int numberHit;
    private bool numbersOrdered;
    [SerializeField] private AudioSource wrongOrder;//Value is private but assigned in the editor. 
    
   
    /*This start method initialises two lists and a game object, generating numbers at random that
     are then assignd to the TextMeshProUGUI objects that are possessed by the OrdinalNumberEnemy.
    */
    void Start()
    {
        numbersToHit = GameObject.FindGameObjectsWithTag("OrdinalNumber");
        numbersSoFar = new List<int>();
        numbers = new List<int>();
        for (int i = 0; i < numbersToHit.Length; i++) {

          
            int randomNumber = Random.Range(1, 20);
            if (!numbers.Contains(randomNumber))//Checking for duplication. 
            {
                numbers.Add(randomNumber);
            }
            else {

                i--;
            }
        }
        int counter = 0;
        foreach (GameObject n in numbersToHit)
        {   TextMeshProUGUI numberText = n.GetComponentInChildren<TextMeshProUGUI>();
            numberText.text = numbers[counter].ToString();
            counter++;
        }

        numbers.Sort();//Sorting the initial list of numbers from smallest to largest. 
        
            
        }

        

    // Update is called once per frame
    void Update()
    {
        
            
        
        CheckNumbers();
        
        
        
    }

    /*Each OrdinalEnemy has three tiny canvases. When a player interacts with these canvases
     the numbers are added to the numbersSoFar list. Once this list is the same length as the 
    initial list of numbers created here, they are compared. For each number that matches,
    the counter variable increments. If the counter = 3, that means the player has matched
    all three numbers correctly and so the enemy is defeated. If not, a correction sound effect is
    played and the numbersSoFar list is cleared. */
    public void CheckNumbers() {
        int counter = 0; 
        
        if (numbers.Count == numbersSoFar.Count) {

            Debug.Log("They're the same size");

            for (int i = 0; i < numbers.Count; i++)
            {

                if (numbers[i] == numbersSoFar[i])
                {
                    counter++;
                    numbersOrdered = true;    

                }

                else
                {
                    numbersOrdered = false;

                }
            }
           
            if (counter==3)
            {
                this.gameObject.SetActive(false);
                OrdinalEnemyManager.enemiesInActive = true;

            }

            else {
 
                numbersSoFar.Clear();
                wrongOrder.Play();
                counter = 0;
            }
            
            }

        
        }

    
    


    
}

/*<!--Number Planet - OrdinalEnemy
@Author: Julian Laffin -->*/
