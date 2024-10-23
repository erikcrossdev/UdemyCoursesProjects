using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertQuaternion : MonoBehaviour
{
    public Vector3 Axis;
    public float angle;
    void Start()
    {
        PrintQuaternion();
    }

    void PrintQuaternion() {
        Axis.Normalize();

        float w = Mathf.Cos(angle * Mathf.Deg2Rad / 2);
        float s = Mathf.Sin(angle * Mathf.Deg2Rad / 2);

        Vector3 quaternion = new Vector3(Axis.x * s, Axis.y * s, Axis.z * s);

        Debug.Log($"Quaternion of {Axis} rotated {angle}º is: ({quaternion.x}, {quaternion.y}, {quaternion.z}, {w} ");

    }
}
