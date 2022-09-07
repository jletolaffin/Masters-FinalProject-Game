using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*An enemy manager script that serves to exist when the OrdinalEnemy does not, allowing certain values
 to be passed on to the level manager. */
public class OrdinalEnemyManager : MonoBehaviour
{
    

    public static bool enemiesInActive;
    public static bool levelCompleted;
    public AudioSource enemiesDefeated;

    /*Initialising a sound effect from attached components.*/
    void Start()
    {
        enemiesDefeated = GetComponent<AudioSource>();
        
    }

    /*Values passed to the relevant level managers to note the enemy's defeat. The Level Managers
     were constructed in different ways due to experimentation throughout the project, hence
    the two different values. Please se those scripts for more details. */
    void Update()
    {
        if (enemiesInActive)
        {
            enemiesDefeated.Play();
            Level4Manager.enemiesDefeated++;
            enemiesInActive = false;
            Level3Manager.levelCompleted = true;
            
        }
    }
}

/*<!--Number Planet - OrdinalEnemyManager
@Author: Julian Laffin -->*/
