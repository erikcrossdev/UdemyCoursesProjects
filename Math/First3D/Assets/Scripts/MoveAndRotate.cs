using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndRotate : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;

    void Update()
    {
        float pitch = Input.GetAxis("Vertical") * rotationSpeed;  //X axis rotation (pitch, 0 , 0)
        float yaw = Input.GetAxis("Horizontal") * rotationSpeed; //Y axis rotation ( 0, pitch, 0)
        float roll = Input.GetAxis("HorizontalZ") * rotationSpeed;//Z axis rotation (0, 0 , pitch)
        float translateZ = Input.GetAxis("VerticalY") * speed;
       
        transform.Rotate(pitch, yaw, roll);

 
        translateZ *= Time.deltaTime;

        transform.Translate(0, 0, translateZ);
        //We need to convert degrees to radians, since unity expects radians

    }
}
