using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject cubeprefab;
    public GameObject spherePrefab;
   
    void Update()
    {
        if ((Random.Range(0, 100) < 10))
        {
            Instantiate(cubeprefab, this.transform.position, Quaternion.identity);
        }
        if ((Random.Range(0, 100) < 10))
        {
            Instantiate(spherePrefab, this.transform.position, Quaternion.identity);
        }

    }
}
