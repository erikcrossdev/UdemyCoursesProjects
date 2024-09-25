using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coords
{
    float x;
    float y;
    float z;

    public Coords(float _x, float _y) 
    { 
        x= _x;
        y= _y;
        z = 1;    
    }

    public override string ToString()
    {
        return string.Concat("(",x,",",y,", ",z, ")");
    }

    static public void DrawPoint(Coords position, float width, Color color) 
    {
        var offset = 3.0f;
        GameObject line = new GameObject("Point_" + position.ToString());
        LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Unlit/Color"));//add a material to see the renderer
        lineRenderer.material.color = color;
        lineRenderer.positionCount = 2; //number of vertices
        lineRenderer.SetPosition(0, new Vector3(position.x - width / offset, position.y - width / offset, position.z));//first point of the line, decrement the width of the line
        lineRenderer.SetPosition(1, new Vector3(position.x + width / offset, position.y + width / offset, position.z));//second point of the line, increment the width of the line
        lineRenderer.startWidth = width; //width of the line
        lineRenderer.endWidth = width; //width of the line
    }

    static public void DrawLine(Coords startPoint, Coords endPoint, float width, Color color)
    {
        var offset = 3.0f;
        GameObject line = new GameObject("Line_" + startPoint.ToString()+"_"+endPoint.ToString());
        LineRenderer lineRenderer = line.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Unlit/Color"));//add a material to see the renderer
        lineRenderer.material.color = color;
        lineRenderer.positionCount = 2; //number of vertices
        lineRenderer.SetPosition(0, new Vector3(startPoint.x, startPoint.y, startPoint.z));//first point of the line, decrement the width of the line
        lineRenderer.SetPosition(1, new Vector3(endPoint.x, endPoint.y, endPoint.z));//second point of the line, increment the width of the line
        lineRenderer.startWidth = width; //width of the line
        lineRenderer.endWidth = width; //width of the line
    }


}
