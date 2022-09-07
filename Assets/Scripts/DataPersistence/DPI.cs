using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This interface, when implemented by objects, allows them to access the below methods which both
 take in a  GameData object. The method then carries out processes appropriate to the function and the
object. See PlayerMovement for an example of these being called. */
public interface DPI
{
    public void LoadGameData(GameData data);

    public void SaveGameData(GameData data);

}

/*<!--Number Planet - DPI Interface
@Author: Julian Laffin -->*/
