using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*A script that sits at the top of the Cardinal Enemy object tree in scene 4.*/
public class CardinalEnemyDom : MonoBehaviour
{
    private AudioSource enemiesDefeated;
    public static bool enemiesInactive;
    
    /*Start method initialises the enemiesDefeated sound effect.*/
    void Start()
    {
        enemiesDefeated = GetComponent<AudioSource>();
    }

    
    /*Checks to see if the enemies are inActive or not. If the variable, which is influenced
     by other scripts, is set to true, a reward sound effect plays and the level's enemiesDefeated
    value increments. Upon reaching a certain value, this variable will then activate a portal from its
    script. */
    void Update()
    {
        if (enemiesInactive) {

            enemiesDefeated.Play();
            Level4Manager.enemiesDefeated++;
            enemiesInactive = false;
            
        }
    }
}


/*<!--Number Planet - CardinalEnemyDom
@Author: Julian Laffin -->*/