using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This Scriptable Object was creatd to assign values to the various tens and one blocks
 users can use to build numbers, and two objects of this type were created in the project. One
was valued at 10 and another valued at 1. */

[CreateAssetMenu(fileName = "BlockValue", menuName = "ScriptableObjects/BlockValue")]
public class ScriptableObjectBlock : ScriptableObject {

    public int value; 
   
}

/*<!--Number Planet - ScriptableObjectBlock
@Author: Julian Laffin -->*/
