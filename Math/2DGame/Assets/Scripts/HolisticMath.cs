using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolisticMath
{
    static public Coords GetNormal(Coords vector)
    {
        float sqrt = Distance(new Coords(0, 0, 0), vector);
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
        float dotDivide = Dot(vector1, vector2) /
            (Distance(new Coords(0, 0, 0), vector1) * Distance(new Coords(0, 0, 0), vector2)); //the length of vector1*vector2
        return Mathf.Acos(dotDivide); //radians For degrees * 180/Mathf.PI;
    }

    static public float AngleInDegrees(Coords vector1, Coords vector2)
    {
        return Angle(vector1, vector2) * 180 / Mathf.PI;
    }

    static public Coords Rotate(Coords vector, float angle, bool clockwise) //angle in radians
    {
        if (clockwise)
        {
            angle = 2 * Mathf.PI - angle; //2 * Mathf.PI is 360 in radians
        }

        float xVal = vector.x * Mathf.Cos(angle) - vector.y * Mathf.Sin(angle);
        float yVal = vector.x * Mathf.Sin(angle) + vector.y * Mathf.Cos(angle);

        return new Coords(xVal, yVal, 0);
    }

    //vector 1 needs to be the facing direction and vector2 the desired direction
    //because Cross product the order matter
    static public Coords Cross(Coords vector1, Coords vector2)
    {
        //easy way to remember
        return new Coords(vector1.y * vector2.z - vector1.z * vector2.y, //x do not have x
                          vector1.z * vector1.x - vector1.x * vector2.z, //y do not have y
                          vector1.x * vector2.y - vector1.y * vector2.x); //z do not have z

    }

    static public Coords LookAt2D(Coords forward, Coords direction)
    {
        float angle = Angle(forward, direction);
        //transform.up = 0,1,0 
        bool clockwise = false;
        if (Cross(forward, direction).z < 0)
        {
            clockwise = true;
        }
        Coords newDir = Rotate(forward, angle, clockwise);
        return newDir;
    }

    static public Coords LookAt2D(Coords forwardVector, Coords position, Coords focusPoint)
    {
        Coords direction = new Coords(focusPoint.x - position.x,
                                      focusPoint.y - position.y,
                                      focusPoint.z - position.z);
        float angle = Angle(forwardVector, direction);
        bool clockwise = false;
        if (Cross(forwardVector, direction).z < 0)
        {
            clockwise = true;
        }
        Coords newDir = Rotate(forwardVector, angle, clockwise);
        return newDir;
    }
}
