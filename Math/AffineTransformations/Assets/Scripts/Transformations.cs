using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformations : MonoBehaviour
{
    public GameObject[] points;
    public GameObject center;
    public Vector3 angle;
    public Vector3 translation;
    public Vector3 scaling;

    private void Start()
    {
        Rotate();
    }

    void Rotate()
    {
        Vector3 c = new Vector3(center.transform.position.x, center.transform.position.y, center.transform.position.z);
        angle = angle * Mathf.Deg2Rad; //convert to radian a degree angle
        foreach (var point in points)
        {
            Coords position = new Coords(point.transform.position, 1);
            //center transform will act like a pivot, so we can turn our object around it, you can move it away from the origin if you like
            //to rotate around the center, we need to translate by the center point, back to the origin, rotate it and then move it back 
            position = HolisticMath.Translate(position,
                new Coords(new Vector3(-c.x, -c.y, -c.z), 0));

            point.transform.position = HolisticMath.Rotate(position, angle.x, true,
                angle.y, true, angle.z, true).ToVector();

            point.transform.position = HolisticMath.Translate(position,
           new Coords(new Vector3(c.x, c.y, c.z), 0)).ToVector();
        }
    }

    void Scale() {
        Vector3 c = new Vector3(center.transform.position.x, center.transform.position.y, center.transform.position.z);
        angle = angle * Mathf.Deg2Rad; //convert to radian a degree angle
        foreach (var point in points)
        {
            Coords position = new Coords(point.transform.position, 1);

            //to rotate around the center, we need to translate by the center point, back to the origin, rotate it and then move it back

            position = HolisticMath.Translate(position,
                new Coords(new Vector3(-c.x, -c.y, -c.z), 0));

            position = HolisticMath.Scale(position, scaling.x, scaling.y, scaling.z);

            point.transform.position = HolisticMath.Translate(position,
              new Coords(new Vector3(c.x, c.y, c.z), 0)).ToVector();
        }
    }

    void Translate() {
        Coords position = new Coords(points[0].transform.position, 1);

        points[0].transform.position = HolisticMath.Translate(position,
           new Coords(new Vector3(translation.x, translation.y, translation.z), 0)).ToVector();

    }
}
