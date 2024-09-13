using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    [SerializeField] private ATTRIBUTES doorType = ATTRIBUTES.MAGIC;
    BoxCollider box;
    void Start()
    {
        box = GetComponent<BoxCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.GetComponent<AttributeManager>().Attributes & doorType) != 0)
        {
            box.isTrigger = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        
            box.isTrigger = false;
        
    }

}
