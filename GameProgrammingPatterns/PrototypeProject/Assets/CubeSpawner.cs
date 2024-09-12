using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{    
    void Update()
    {
        if (Random.Range(0, 100) < 10) {
            ProcCube.Clone(this.transform.position);
        }
        if (Random.Range(0, 100) < 10)
        {
            CreateSphereProcedural.Clone(this.transform.position);
        }
    }
}
