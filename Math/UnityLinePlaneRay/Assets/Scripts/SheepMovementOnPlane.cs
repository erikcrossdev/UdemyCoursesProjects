using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMovementOnPlane : MonoBehaviour
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
        mPlane = new Plane(quad.transform.TransformPoint(verticies[0] + new Vector3(0, 2.9f, 0)), //sum to the sheep do not sink into the ground
            quad.transform.TransformPoint(verticies[1] + new Vector3(0, 2.9f, 0)),
            quad.transform.TransformPoint(verticies[2] + new Vector3(0, 2.9f, 0))
            );
        //mPlane = new Plane(corner1.position, corner2.position, corner3.position);
        Debug.Log(verticies[0]);
        Debug.Log(verticies[1]);
        Debug.Log(verticies[2]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float t = 0.0f;

            if (mPlane.Raycast(ray, out t))
            {
                Vector3 hitPoint = ray.GetPoint(t);
                float hitPointX = hitPoint.x;
                float hitPointZ = hitPoint.z;
                //keep sheep in the bounds of the plane
                if(hitPointX >= -6 && hitPointX <= 6 && hitPointZ >= -6 && hitPointZ<= 6)
                    sphere.transform.position = hitPoint;
            }
        }

    }
}
