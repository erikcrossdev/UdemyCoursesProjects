using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject objPrefab;
    public Vector3 objectPosition;

 //Instantiate on awake for object position update first
    void Awake()
    {
        GameObject obj = Instantiate(objPrefab, new Vector3(Random.Range(-100, 100),
                                                            Random.Range(-100,100),
                                                            objPrefab.transform.position.z),
                                                            Quaternion.identity);
        objectPosition = obj.transform.position;

        //Debug.Log("Fuel Location " + obj.transform.position);
    }

}
