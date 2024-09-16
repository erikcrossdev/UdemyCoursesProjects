using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class DoorWithKeyManager : MonoBehaviour
{
    public int type;
    BoxCollider _collider;

    private void Start()
    {
        _collider = GetComponent<BoxCollider>();
        switch (gameObject.tag) {
            case "GREEN_DOOR":
                type = (int)KEYS.BLUEKEY;
                break;                
            case "YELLOW_DOOR":
                type = (int)KEYS.GOLD_KEY;
                break;
            case "BLUE_DOOR":
                type = (int)KEYS.BLUEKEY;
                break;
            case "PURPLE_DOOR":
                type = (int)(KEYS.BLUEKEY | KEYS.REDKEY);
                break;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //& operator will be true only when 1s are filled
        if (((int)collision.gameObject.GetComponent<KeysManager>().Keys & type) == type) 
        {
            _collider.isTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _collider.isTrigger = false;
        other.gameObject.GetComponent<KeysManager>().RemoveKey((KEYS)type) ;
    }
}
