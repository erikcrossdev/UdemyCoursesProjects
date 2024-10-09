using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLine : MonoBehaviour
{
    public Transform start;
    public Transform end;
    Line line;
    float cumulativeTime;

    private void Start()
    {
        line = new Line(new Coords(start.position), new Coords(end.position), LineType.SEGMENT);
    }

    private void Update()
    {
        cumulativeTime += Time.deltaTime * 0.2f;
        // this.transform.position = line.Lerp(cumulativeTime).ToVector(); //THIS IS THE SAME AS A LERP: Linear interpolation
        transform.position = HolisticMath.Lerp(new Coords(start.position), new Coords(end.position), cumulativeTime).ToVector();
    }

}
