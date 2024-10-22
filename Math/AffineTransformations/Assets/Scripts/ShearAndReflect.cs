using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShearAndReflect : MonoBehaviour
{
    public GameObject[] points;
    public GameObject center;
    public Vector3 angle;
    public Vector3 translation;
    public Vector3 scaling;
    public Vector3 shear;

    private void Start()
    {
        //Shear();
        Reflect();
        DrawLines();
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

    void Reflect() {
        foreach (var point in points)
        {
            Coords position = new Coords(point.transform.position, 1);

            point.transform.position = HolisticMath.Reflect(position, true, false, false).ToVector();
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

    void Shear() {
       
        foreach (var point in points)
        {
            Coords position = new Coords(point.transform.position, 1);

            point.transform.position = HolisticMath.Shear(position, shear.x, shear.y, shear.z).ToVector();
        }
    }

    void DrawLines() {
        //base
        Coords.DrawLine(new Coords(points[0].transform.position), new Coords(points[1].transform.position), 0.05f, Color.yellow);
        Coords.DrawLine(new Coords(points[1].transform.position), new Coords(points[2].transform.position), 0.05f, Color.yellow);
        Coords.DrawLine(new Coords(points[2].transform.position), new Coords(points[3].transform.position), 0.05f, Color.yellow);
        Coords.DrawLine(new Coords(points[3].transform.position), new Coords(points[0].transform.position), 0.05f, Color.yellow);

        //plane right
        Coords.DrawLine(new Coords(points[1].transform.position), new Coords(points[5].transform.position), 0.05f, Color.yellow);
        Coords.DrawLine(new Coords(points[5].transform.position), new Coords(points[6].transform.position), 0.05f, Color.yellow);
        Coords.DrawLine(new Coords(points[2].transform.position), new Coords(points[6].transform.position), 0.05f, Color.yellow);

        //front
        Coords.DrawLine(new Coords(points[6].transform.position), new Coords(points[7].transform.position), 0.05f, Color.yellow);
        Coords.DrawLine(new Coords(points[3].transform.position), new Coords(points[7].transform.position), 0.05f, Color.yellow);

        //left
        Coords.DrawLine(new Coords(points[4].transform.position), new Coords(points[7].transform.position), 0.05f, Color.yellow);
        Coords.DrawLine(new Coords(points[0].transform.position), new Coords(points[4].transform.position), 0.05f, Color.yellow);

        //back
        Coords.DrawLine(new Coords(points[4].transform.position), new Coords(points[5].transform.position), 0.05f, Color.yellow);

        //roof front
        Coords.DrawLine(new Coords(points[6].transform.position), new Coords(points[9].transform.position), 0.05f, Color.yellow);
        Coords.DrawLine(new Coords(points[7].transform.position), new Coords(points[9].transform.position), 0.05f, Color.yellow);

        //roof back
        Coords.DrawLine(new Coords(points[5].transform.position), new Coords(points[8].transform.position), 0.05f, Color.yellow);
        Coords.DrawLine(new Coords(points[4].transform.position), new Coords(points[8].transform.position), 0.05f, Color.yellow);

        //roof top
        Coords.DrawLine(new Coords(points[8].transform.position), new Coords(points[9].transform.position), 0.05f, Color.yellow);

    }
}
