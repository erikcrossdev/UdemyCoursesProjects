using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGraph : MonoBehaviour
{
    [SerializeField] float offset = 20;

    int sizeX = 160;
    int sizeY = 100;
    int arrayXsize;
    // Start is called before the first frame update

   
    void Start()
    {
        int arrayXsize = sizeX * 2 / (int)offset;
        int arrayYsize = sizeY * 2 / (int)offset;
        Coords[] graphX = new Coords[arrayXsize];
        Coords[] graphY = new Coords[arrayYsize];

        Coords.DrawLine(new Coords(-0, -100), new Coords(0, 100), 1.0f, Color.green);
        Coords.DrawLine(new Coords(160, 0), new Coords(-160, 0), 1.0f, Color.red);

        float xIncrement = -160;
        for (int i = 0; i < arrayXsize; i++) {
            graphX[i] = new Coords(xIncrement, -100);
            Coords.DrawLine(graphX[i], new Coords(xIncrement, 100), 1.0f, Color.white);
            xIncrement += offset;
        }

        float yIncrement = -100;
        for (int i = 0; i < arrayYsize; i++)
        {
            graphX[i] = new Coords(-160, yIncrement);
            Coords.DrawLine(graphX[i], new Coords(160, yIncrement), 1.0f, Color.white);
            yIncrement += offset;
        }
    }

}
