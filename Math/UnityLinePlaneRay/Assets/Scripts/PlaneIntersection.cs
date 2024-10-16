using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneIntersection : MonoBehaviour
{
    //[SerializeField] Transform corner1;
    //[SerializeField] Transform corner2;
    //[SerializeField] Transform corner3;
    [SerializeField] GameObject quad;

    [SerializeField] GameObject sphere;

    Plane mPlane;
    // Start is called before the first frame update
    void Start()
    {
        Vector3[] verticies = quad.GetComponent<MeshFilter>().mesh.vertices;
        mPlane = new Plane(quad.transform.TransformPoint(verticies[0]), 
            quad.transform.TransformPoint(verticies[1]),
            quad.transform.TransformPoint(verticies[2])
            );
        //mPlane = new Plane(corner1.position, corner2.position, corner3.position);
        Debug.Log(verticies[0]);
        Debug.Log(verticies[1]);
        Debug.Log(verticies[2]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float t = 0.0f;

            if (mPlane.Raycast(ray, out t))
            {
                Vector3 hitPoint = ray.GetPoint(t);
                sphere.transform.position = hitPoint;
            }
        }

    }
}
