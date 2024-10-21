using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformations : MonoBehaviour
{
    public GameObject[] points;
    public GameObject center;
    public float angle;
    public Vector3 translation;
    public Vector3 scaling;

    private void Start()
    {
        Vector3 c = new Vector3(center.transform.position.x, center.transform.position.y, center.transform.position.z);
        foreach (var point in points)
        {
            Coords position = new Coords(point.transform.position, 1);

            //point.transform.position = HolisticMath.Translate(position,
             //   new Coords(new Vector3(translation.x, translation.y, translation.z), 0)).ToVector();

            position = HolisticMath.Translate(position,
                new Coords(new Vector3(-c.x, -c.y, -c.z), 0));

            position = HolisticMath.Scale(position, scaling.x, scaling.y, scaling.z);

            point.transform.position = HolisticMath.Translate(position,
              new Coords(new Vector3(c.x, c.y, c.z), 0)).ToVector();



        }
    }
}
