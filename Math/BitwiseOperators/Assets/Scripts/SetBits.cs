using System;
using UnityEngine;

public class SetBits : MonoBehaviour
{
    int bSequnece = 8 + 1 + 2;
    void Start()
    {
        Debug.Log(Convert.ToString(bSequnece, 2)); //Convert to base 2
    }

}
