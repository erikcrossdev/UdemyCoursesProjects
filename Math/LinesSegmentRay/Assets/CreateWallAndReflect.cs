using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWallAndReflect : MonoBehaviour
{
    Line wall;
    Line ballPath;
    public GameObject ball;

    Line ballTrajectory;
    float t = 0.01f;
    float speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        wall = new Line(new Coords(5, -2, 0), new Coords(0, 5, 0));
        wall.DrawLine(1, Color.blue);

        ballPath = new Line(new Coords(-6, 2, 0), new Coords(100, 0, 0));
        ballPath.DrawLine(0.1f, Color.yellow);

        ball.transform.position = ballPath.Avector.ToVector(); //Get the A vector

        float intersectT = ballPath.IntersectAt(wall);
        float intersectS = wall.IntersectAt(ballPath);

        if (intersectT == intersectT && intersectS == intersectS) //it is weird, but with this we test if NaN
        {
            var endPos = transform.position = ballPath.Lerp(intersectT).ToVector();
            ballTrajectory = new Line(new Coords(-6, 0, 0), new Coords(endPos), LineType.SEGMENT);

            //GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //sphere.transform.position = endPos;

            ballTrajectory.DrawLine(0.1f, Color.white);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (t <= 1)
        {
            t += Time.deltaTime * speed;
            ball.transform.position = ballTrajectory.Lerp(t).ToVector();
        }
        else {
            ball.transform.position += ballTrajectory.Reflect(Coords.Perp(wall.Vvector)).ToVector() * Time.deltaTime * 5;
        }
    }
}
