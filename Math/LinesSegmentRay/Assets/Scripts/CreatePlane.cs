using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class CreatePlane : MonoBehaviour
{
    public Transform A;
    public Transform B;
    public Transform C;
    Plane plane;
    // Start is called before the first frame update
    void Start()
    {
        Plane plane = new Plane(new Coords(A.position), new Coords(B.position), new Coords(C.position));
        for (float s = 0; s < 1; s+= 0.1f)
        {
            for (float t = 0; t < 1; t+= 0.1f)
            {
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.transform.position = plane.Lerp(s,t).ToVector();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
