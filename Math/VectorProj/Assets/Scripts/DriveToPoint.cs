using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveToPoint : MonoBehaviour
{

    float speed = 0.5f;
    public GameObject fuel;
    float stopDistance =0.1f;
    Vector3 direction;

    private void Start()
    {
        direction = fuel.transform.position - transform.position;
       
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, fuel.transform.position) > stopDistance)
        {
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
