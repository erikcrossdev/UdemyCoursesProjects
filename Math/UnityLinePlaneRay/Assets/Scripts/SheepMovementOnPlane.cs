using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMovementOnPlane : MonoBehaviour
{
    [SerializeField] GameObject quad;
    [SerializeField] GameObject[] fences;
    Vector3[] fencesNormals;

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

        Debug.Log(verticies[0]);
        Debug.Log(verticies[1]);
        Debug.Log(verticies[2]);

        fencesNormals = new Vector3[fences.Length];
        for (int i = 0; i < fences.Length; i++)
        {
            //get the normal of the mesh
            Vector3 normal = fences[i].GetComponent<MeshFilter>().mesh.normals[0]; //they are quads, so the normals are equal
            //we need to transform to world position
            fencesNormals[i] = fences[i].transform.TransformVector(normal);
        }
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

                bool insideFence = true;
                for (int i = 0; i < fences.Length; i++)
                {
                    Vector3 hitPointToFence = fences[i].transform.position - hitPoint;
                    insideFence = insideFence && Vector3.Dot(hitPointToFence, fencesNormals[i]) <= 0;
                }
                if (insideFence)
                {
                    sphere.transform.position = hitPoint;
                }
            }
        }

    }
}
