using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This CameraMovement script is only used in certain scenes in the game, but allows
 the player to remain central to the screen whilst giving the user a good view of what
content is to come.*/
public class CameraMovement : MonoBehaviour
{
    private Vector3 offset = new Vector3(0,+7,-30);
    private float targetTime = 0.1f;
    private Vector3 velocity;
    [SerializeField] private Transform target;
    

    

    /*This update method allows the camera to smoothly follow the player at a slight offset,
     meaning that the camera leans slightly ahead to the right to allow a good view of upcoming
    obstacles for the user.*/
    void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position,
            targetPosition, ref velocity, targetTime);
    }
}

/*<!--Number Planet - CamerMovement
@Author: Julian Laffin -->*/