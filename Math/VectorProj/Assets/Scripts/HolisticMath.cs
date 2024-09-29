using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolisticMath 
{
    static public Coords GetNormal(Coords vector) 
    {
        float sqrt = Distance (new Coords(0,0,0), vector);
        Coords newVec = new Coords(vector.x / sqrt, vector.y / sqrt, vector.z / sqrt);
        return newVec;
    }

    static public float Distance(Coords target, Coords position) 
    {
        float diffSquared = Square(target.x - position.x) +
                            Square(target.y - position.y) +
                            Square(target.z - position.z);
        float squareRoot = Mathf.Sqrt(diffSquared);
        return squareRoot;
    }

    static public float Square(float value) 
    {
        return value * value;
    }

}
