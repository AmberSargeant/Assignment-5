using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionCamera : MonoBehaviour
{
    //define player game object
    public GameObject player;

    //wait for lateupdate
    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, 2f, -10f);
    }
}