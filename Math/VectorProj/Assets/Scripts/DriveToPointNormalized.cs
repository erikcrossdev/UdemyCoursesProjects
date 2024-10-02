using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveToPointNormalized : MonoBehaviour
{
    float speed = 10f;
    public GameObject fuel;
    float stopDistance = 0.1f;
    Vector3 direction;

    private void Start()
    {
        direction = fuel.transform.position - transform.position;
        Coords dirNormal = HolisticMath.GetNormal(new Coords(direction));
        direction = dirNormal.ToVector();

        transform.up = HolisticMath.LookAt2D(new Coords(transform.up),
            new Coords(transform.position),
            new Coords(fuel.transform.position)).ToVector();
    }
    void Update()
    {
        if (HolisticMath.Distance(new Coords(transform.position), new Coords(fuel.transform.position)) > stopDistance)
        {
            transform.position += direction * speed * Time.deltaTime;
        }
        /*
         //or using unity built-in functions
        if (Vector3.Distance(transform.position, fuel.transform.position) > stopDistance)
        {
            transform.position += direction * speed * Time.deltaTime;
        }*/
    }
}
