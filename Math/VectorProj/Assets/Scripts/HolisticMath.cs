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

    static public float Dot(Coords vector1, Coords vector2) 
    { 
        return (vector1.x * vector2.x) + (vector1.y * vector2.y) + (vector1.z * vector2.z);
    }

    static public float Angle(Coords vector1, Coords vector2)
    {
        float dotDivide = Dot(vector1, vector2)/
            (Distance(new Coords(0,0,0), vector1) * Distance(new Coords(0, 0, 0), vector2)); //the length of vector1*vector2
        return Mathf.Acos(dotDivide); //radians For degrees * 180/Mathf.PI;
    }

    static public float AngleInDegrees(Coords vector1, Coords vector2)
    {
        return Angle(vector1, vector2) * 180/Mathf.PI;
    }

    static public Coords Rotate(Coords vector, float angle) //angle in radians
    {
        float xVal = vector.x * Mathf.Cos(angle) - vector.y * Mathf.Sin(angle);
        float yVal = vector.x * Mathf.Sin(angle) + vector.y * Mathf.Cos(angle);

        return new Coords(xVal, yVal , 0);
    }
}
