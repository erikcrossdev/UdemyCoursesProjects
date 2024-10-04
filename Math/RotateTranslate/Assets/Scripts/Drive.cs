using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;

    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        transform.Translate(0, translation, 0);
        transform.position = HolisticMath.Translate(new Coords(transform.position), new Coords(transform.up), new Coords(0, translation, 0)).ToVector();

        transform.up = HolisticMath.Rotate(new Coords(transform.up), rotation * Mathf.Deg2Rad, true).ToVector(); 
        //We need to convert degrees to radians, since unity expects radians
    }
}
