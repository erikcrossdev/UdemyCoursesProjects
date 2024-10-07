using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlane : MonoBehaviour
{
    public float rotationSpeed = 1.0f;

    void Update()
    {
        float pitch = Input.GetAxis("Vertical") *rotationSpeed;  //X axis rotation (pitch, 0 , 0)
        float yaw = Input.GetAxis("Horizontal") * rotationSpeed; //Y axis rotation ( 0, pitch, 0)
        float roll = Input.GetAxis("HorizontalZ") * rotationSpeed;//Z axis rotation (0, 0 , pitch)

        transform.Rotate(pitch, yaw, roll);
    }
}
