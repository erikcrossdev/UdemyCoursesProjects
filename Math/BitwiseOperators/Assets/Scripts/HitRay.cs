using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitRay : MonoBehaviour
{
   
    void Update()
    {
        int cubeMask = 1 << 7;
        int sphereMask = 1 << 6 ; //Sphere, layer 6, or 00100000

        int layerMask = 0;
        layerMask |= (cubeMask | sphereMask); // test all, but negate layer 6
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
            Debug.Log("Hit");
        }
        else {
            Debug.DrawRay(transform.position, transform.forward * 1000, Color.white);
            Debug.Log("Missed");
        }
    }
}
