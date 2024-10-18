using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMatrix : MonoBehaviour
{
     
    void Start()
    {
        float[] vals = { 1, 2, 3, 4, 5, 6 };
        Matrix m = new Matrix(2, 3, vals);
        Debug.Log(m.ToString());

        float[] vals2 = { 1, 1, 1, 1, 1, 1 };
        Matrix m2 = new Matrix(2, 3, vals2);

        Debug.Log(m2.ToString());

        Matrix result = m + m2;

        Debug.Log(result.ToString());

    }
   
}
