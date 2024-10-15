using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlaneBall : MonoBehaviour
{
    public Transform A;
    public Transform B;
    public Transform C;
    public Transform D;
    public Transform E;

    public GameObject ball;

    float t = 0.01f;
    float speed = 0.5f;

    Plane wall; //A, B, C
    Line ballTrajectory; //D, E
    Line ballPath;

    void Start()
    {
        wall = new Plane(new Coords(A.position),
                            new Coords(B.position),
                            new Coords(C.position));

        for (float s = 0; s <= 1; s += 0.1f)
        {
            for (float t = 0; t <= 1; t += 0.1f)
            {
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.position = wall.Lerp(s, t).ToVector();
            }
        }

        ballPath = new Line(new Coords(D.position), new Coords(E.position), LineType.RAY);
        ballPath.DrawLine(0.1f, Color.green);

        ball.transform.position = ballPath.Avector.ToVector(); //Get the A vector
          

        float intersectT = ballPath.IntersectAt(wall);

        if (intersectT == intersectT) {
            ballTrajectory = new Line(ballPath.Avector, ballPath.Lerp(intersectT), LineType.SEGMENT);

        }
    }

    void Update()
    {
        if(ballTrajectory == null) { return; }
        if (t <= 1)
        {
            t += Time.deltaTime * speed;
            ball.transform.position = ballTrajectory.Lerp(t).ToVector();
        }
        else
        {
            ball.transform.position += ballTrajectory.Reflect(HolisticMath.Cross(wall.Vvec, wall.Uvec)).ToVector() * Time.deltaTime * 10;
            //USE CROSS TO BE 3D
        }
    }


}
