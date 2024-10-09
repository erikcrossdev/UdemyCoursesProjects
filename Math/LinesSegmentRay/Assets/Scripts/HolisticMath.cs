using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolisticMath
{
    static public Coords GetNormal(Coords vector)
    {
        float length = Distance(new Coords(0, 0, 0), vector);
        vector.x /= length;
        vector.y /= length;
        vector.z /= length;

        return vector;
    }

    static public float Distance(Coords point1, Coords point2)
    {
        float diffSquared = Square(point1.x - point2.x) + 
                            Square(point1.y - point2.y) + 
                            Square(point1.z - point2.z);
        float squareRoot = Mathf.Sqrt(diffSquared);
        return squareRoot;

    }

    static public float Square(float value)
    {
        return value * value;
    }

    static public float Dot(Coords vector1, Coords vector2)
    {
        return (vector1.x * vector2.x + vector1.y * vector2.y + vector1.z * vector2.z);
    }

    static public float Angle(Coords vector1, Coords vector2)
    {
        float dotDivide = Dot(vector1, vector2) /
                    (Distance(new Coords(0, 0, 0), vector1) * Distance(new Coords(0, 0, 0), vector2));
        return Mathf.Acos(dotDivide); //radians.  For degrees * 180/Mathf.PI;
    }

    static public Coords LookAt2D(Coords forwardVector, Coords position, Coords focusPoint)
    {
        Coords direction = new Coords(focusPoint.x - position.x, focusPoint.y - position.y, position.z);
        float angle = HolisticMath.Angle(forwardVector, direction);
        bool clockwise = false;
        if (HolisticMath.Cross(forwardVector, direction).z < 0)
            clockwise = true;

        Coords newDir = HolisticMath.Rotate(forwardVector, angle, clockwise);
        return newDir;
    }

    static public Coords Rotate(Coords vector, float angle, bool clockwise) //in radians
    {
        if(clockwise)
        {
            angle = 2 * Mathf.PI - angle;
        }

        float xVal = vector.x * Mathf.Cos(angle) - vector.y * Mathf.Sin(angle);
        float yVal = vector.x * Mathf.Sin(angle) + vector.y * Mathf.Cos(angle);
        return new Coords(xVal, yVal, 0);
    }

    static public Coords Cross(Coords vector1, Coords vector2)
    {
        float xMult = vector1.y * vector2.z - vector1.z * vector2.y;
        float yMult = vector1.z * vector2.x - vector1.x * vector2.z;
        float zMult = vector1.x * vector2.y - vector1.y * vector2.x;
        Coords crossProd = new Coords(xMult, yMult, zMult);
        return crossProd;
    }

    static public Coords Translate(Coords position, Coords facingDirection, Coords vector) {
        if (Distance(new Coords(0, 0, 0), vector) <= 0) return position;
        float angle = Angle(vector, facingDirection);
        float worldAngle = Angle(vector, new Coords(0, 1, 0)); //get our angle relatice to world up angle
        bool clockwise = false;
        if (Cross(vector, facingDirection).z < 0) {
            clockwise = true;
        }
        //match local coordinates to world coordinate space
        vector = Rotate(vector, angle + worldAngle, clockwise); //angle + worldAngle applies the worldAngle to the the angle relative to the local forward
        float x = position.x + vector.x;
        float y = position.y + vector.y;
        float z = position.z + vector.z;

        return new Coords(x, y, z);
    }

    static public Coords Lerp(Coords A, Coords B, float t)
    {
        Coords v = new Coords(B.x - A.x, B.y - A.y, B.z - A.z);
        t = Mathf.Clamp(t, 0, 1);

        float tx = A.x + v.x * t;
        float ty = A.y + v.y * t;
        float tz = A.z + v.z * t;

        return new Coords(tx, ty, tz);
    }

}
