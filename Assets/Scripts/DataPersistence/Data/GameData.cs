using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*The GameData class, whose attributes are what data is saved upon the player saving the game.
 System Serializable indicates that objects of this class can be converted into data. */
[System.Serializable]
public class GameData
{
    public int currentLevel;
    public List<string> timeOnLevel;
    


    /*The constructor. The GameData contains two simple values, which are the level the player
     is currently on, and the times they have spent on each level. */
    public GameData() { 
    
        currentLevel = 0;
        timeOnLevel = new List<string>();


    }
}

/*<!--Number Planet - GameData
@Author: Julian Laffin -->*/