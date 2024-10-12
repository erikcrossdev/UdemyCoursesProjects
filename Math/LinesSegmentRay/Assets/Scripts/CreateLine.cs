using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLine : MonoBehaviour
{
    Line line1;
    Line line2;
    Line line3;
    // Start is called before the first frame update
    void Start()
    {
        line1 = new Line(new Coords(-100, 0, 0), new Coords(200, 150, 0));
        line1.DrawLine(1, Color.green);
        //intersection with line segment
        //line2 = new Line(new Coords(0, -100, 0), new Coords(0, 200, 0));

        //parallel line error
        //line2 = new Line(new Coords(-100, 10, 0), new Coords(200, 150, 0));

        //no intersection with line segment, only with line
        line2 = new Line(new Coords(-100, 10, 0), new Coords(0, 50, 0));
        line2.DrawLine(1, Color.red);

        float intersectT = line1.IntersectAt(line2);
        float intersectS = line2.IntersectAt(line1);

        if (intersectT == intersectT && intersectS == intersectS) //it is weird, but with this we test if NaN
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = line1.Lerp(intersectT).ToVector();
        }
        //Debug.Log("T " + intersectT + " S " + intersectS);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
