using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGraphSolution : MonoBehaviour
{
    public int size = 20;

    public int Xmax = 200;
    public int Ymax = 500;

    Coords startPointXAxis;
    Coords endPointXAxis; 

    Coords startPointYAxis;
    Coords endPointYAxis; 


    private void Start()
    {
        startPointXAxis = new Coords(Xmax, 0);
        endPointXAxis = new Coords(-Xmax, 0);

        startPointYAxis = new Coords(0, Ymax);
        endPointYAxis = new Coords(0, -Ymax);

        Coords.DrawLine(startPointXAxis, endPointXAxis, 1.5f, Color.red);
        Coords.DrawLine(startPointYAxis, endPointYAxis, 1.5f, Color.green);


        int xOffset = (int)(160 / (float)size);
        int yOffset = (int)(100 / (float)size);
        for (int x = -xOffset * size; x <= xOffset * size; x += size) {
            Coords.DrawLine(new Coords(x, -Ymax), new Coords(x, Ymax), 0.5f, Color.white);
        }

        for (int y = -yOffset* size; y <= yOffset * size; y+=size)
        {
            Coords.DrawLine(new Coords(-Xmax, y), new Coords(Xmax, y), 0.5f, Color.white);
        }
    }

}
