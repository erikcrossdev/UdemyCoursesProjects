using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    float speed = 10.0f;
    float rotationSpeed = 100.0f;

    void Update()
    {

        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        Move(0, 0, translation);// the z axis of the plane
        transform.Rotate(0, rotation, 0);
    }

    private void Move(float x, float y, float z)
    {
        Matrix4x4 worldtransform = transform.localToWorldMatrix;
        Vector4 airplaneWorldForward = worldtransform.GetColumn(2) * z;
        //move relative to the local position, multiplying just Z. 
        transform.position += new Vector3(airplaneWorldForward.x, airplaneWorldForward.y, airplaneWorldForward.z);
    }

    private void MoveWorldPos(float x, float y, float z) {
        //Move relative to the world position
        transform.position += new Vector3(x, y, z);
    }
}
