using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLines : MonoBehaviour
{

    Coords point = new Coords(10, 20);
    void Start()
    {
        //Debug.Log(point.ToString());
        //Coords.DrawPoint(point, 2, Color.green);
        Coords.DrawLine(new Coords(0, 100), new Coords(0,-100), 0.5f, Color.green);//Y axis
        Coords.DrawLine(new Coords(160, 0), new Coords(-160, 0), 0.5f, Color.red);// X axis
                                                                                  //Coords.DrawPoint(new Coords(0,0), 2, Color.blue);

        float scale = 2f;
        Coords[] capricorn = {new Coords(1 * scale, 1 * scale),
            new Coords(4 * scale, 7 * scale),
            new Coords(16 * scale, 14 * scale),
            new Coords(27 * scale, 28 * scale),
            new Coords(28.5f * scale, 35 * scale),
            new Coords(28.5f * scale, 1.5f * scale),
            new Coords(27.5f * scale, -1.0f * scale),
            new Coords(13 * scale, -2.0f * scale),
            new Coords(6 * scale, 1 * scale)
        };

        for (int i = 0; i < capricorn.Length; i++) {
            Coords.DrawPoint(capricorn[i], 2, Color.yellow);
        }


        Coords.DrawLine(capricorn[0], capricorn[1], 0.5f, Color.white);
        Coords.DrawLine(capricorn[1], capricorn[2], 0.5f, Color.blue);
        Coords.DrawLine(capricorn[2], capricorn[3], 0.5f, Color.yellow);
        Coords.DrawLine(capricorn[3], capricorn[4], 0.5f, Color.cyan);
       
        Coords.DrawLine(capricorn[3], capricorn[5], 0.5f, Color.red);
        Coords.DrawLine(capricorn[5], capricorn[6], 0.5f, Color.magenta);
        Coords.DrawLine(capricorn[6], capricorn[7], 0.5f, Color.gray);

        Coords.DrawLine(capricorn[7], capricorn[8], 0.5f, Color.white);
        Coords.DrawLine(capricorn[8], capricorn[0], 0.5f, Color.blue);




    }

}
