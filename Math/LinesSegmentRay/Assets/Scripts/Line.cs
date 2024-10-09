using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LineType { LINE, SEGMENT, RAY}
public class Line 
{
    Coords A;
    Coords B;
    Coords v;
    LineType type;

    public Line(Coords _A, Coords _B, LineType t) {
        A= _A;
        B = _B;
        v = new Coords(B.x - A.x, B.y - A.y, B.z - A.z);
        type = t;
    }

    //depending on the type, we need to limitate the t
    public Coords Lerp(float t) {

        if (type == LineType.SEGMENT)
        {
            t = Mathf.Clamp(t, 0 , 1);
            Debug.Log("Clamp");
        }
        else if (type == LineType.RAY && t < 0) 
        {
            t = 0.0f;
        }
       
        Debug.Log("t " + t);
        float tx = A.x + v.x * t;
        float ty = A.y + v.y * t;
        float tz = A.z + v.z * t;

        return new Coords(tx, ty, tz);
    }

      
}
