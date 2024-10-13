using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LineType { LINE, SEGMENT, RAY }
public class Line
{
    Coords A;
    public Coords Avector => A;
    Coords B;
    Coords v;
    public Coords Vvector => v;
    LineType type;

    public Line(Coords _A, Coords _B, LineType t)
    {
        A = _A;
        B = _B;
        v = new Coords(B.x - A.x, B.y - A.y, B.z - A.z);
        type = t;
    }

    public Line(Coords _A, Coords _v)
    {
        A = _A;
        B = A + _v;
        v = _v;
        type = LineType.SEGMENT;
    }

    public void DrawLine(float width, Color color)
    {
        Coords.DrawLine(A, B, width, color);
    }

    public Coords Reflect(Coords normal) {

        var norm = normal.GetNormal();
        var vnorm = v.GetNormal();

        float dot = HolisticMath.Dot(norm, vnorm);

        float vn2 = dot * 2;

        Coords r = vnorm - norm * vn2;

        return r; 
    
    }

    public float IntersectAt(Plane plane)
    { 
        Coords normal = HolisticMath.Cross(plane.Uvec, plane.Vvec);
        if (HolisticMath.Dot(normal, v) == 0) return float.NaN; //if the plane and the line are parallel, then we do not have intersections

        float t = HolisticMath.Dot(normal, plane.Avec - A) / HolisticMath.Dot(normal, v);
        return t;
    }

    public float IntersectAt(Line line)
    {
        //test if the line is parallel, because we will not have an intersection
        if (HolisticMath.Dot(Coords.Perp(line.v), v) == 0)
        {
            return float.NaN;
        }

        Coords c = line.A - this.A;
        float t = HolisticMath.Dot(Coords.Perp(line.v), c)
            /
            HolisticMath.Dot(Coords.Perp(line.v), v);
        if ((t < 0 || t > 1) && type == LineType.SEGMENT)
        {
            return float.NaN;
        }
        return t;
    }

    //depending on the type, we need to limitate the t
    public Coords Lerp(float t)
    {

        if (type == LineType.SEGMENT)
        {
            t = Mathf.Clamp(t, 0, 1);
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
