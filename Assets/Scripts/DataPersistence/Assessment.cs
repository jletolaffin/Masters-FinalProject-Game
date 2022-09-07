using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*This Assessment script creates an Assessment Object which persists throughout gameplay
 as durations of time spent on levels are added to it from elsewhere.*/
public class Assessment : MonoBehaviour
{

    public static List<string> levelTimes;
    


    /*Tells Unity not to destroy the object when scenes are unloaded or loaded. The awake
     method is the best place for this as it is called before any other method, including start. */
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    /*If the levelTimes List has not been created yet, which happens if a player starts a new game,
     it is created. Otherwise the values are printed to the console for debugging purposes. */
    void Start()
    {
        Debug.Log("Assessment Object present");
        if (levelTimes == null)
        {

            levelTimes = new List<string>();
        }
        else
        {
            foreach (string s in levelTimes)
            {

                Debug.Log("Assessment Data " + s);
            }
        }
    }

    
}

/*<!--Number Planet - Assesment
@Author: Julian Laffin -->*/
