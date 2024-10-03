using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DriveAngleInput : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotationSpeed = 100.0f;
    public float angleDegrees = 0f;
    public TextMeshProUGUI energyAmount;

    Vector3 currentLocation;

    private void Start()
    {
        currentLocation = transform.position;
    }
    void Update()
    {
        if (float.Parse(energyAmount.text) <= 0) return;
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;
        
        // Move translation along the object's z-axis
        transform.Translate(0, translation, 0);

        energyAmount.text = (float.Parse(energyAmount.text) - Vector3.Distance(currentLocation,
                                                            this.transform.position)) + "";
        currentLocation = transform.position;
    }

    public void ChangeAngle(float angle) {

        float n = angle;
        n *= Mathf.PI / 180.0f; //convert degrees to radians
                                //Or 
                                //n*=Mathf.Deg2Rad;
        transform.up = HolisticMath.Rotate(new Coords(transform.up), n, false).ToVector();
    }
}
