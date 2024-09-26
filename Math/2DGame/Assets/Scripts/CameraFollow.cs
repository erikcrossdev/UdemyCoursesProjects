using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;


    void Update()
    {
        this.transform.position = new Vector3(
            player.position.x,
            player.position.y,
            transform.position.z
        );
    }
}
