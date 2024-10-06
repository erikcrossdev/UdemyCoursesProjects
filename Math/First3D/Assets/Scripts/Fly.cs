using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;

    void Update()
    {
        float translateX = Input.GetAxis("Horizontal") * speed;
        float translateY = Input.GetAxis("VerticalY") * speed;
        float translateZ = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("HorizontalZ") * rotationSpeed;

        translateX *= Time.deltaTime;
        translateY *= Time.deltaTime;
        translateZ *= Time.deltaTime;
        rotation *= Time.deltaTime;

        transform.Translate(translateX, translateY, translateZ);
        transform.up = HolisticMath.Rotate(new Coords(transform.up), rotation * Mathf.Deg2Rad, true).ToVector();
        //We need to convert degrees to radians, since unity expects radians

    }
}
