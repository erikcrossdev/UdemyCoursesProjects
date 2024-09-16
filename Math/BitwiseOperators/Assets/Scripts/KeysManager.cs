using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Flags]
public enum KEYS {
   REDKEY = 8,
    BLUEKEY = 4,
    GOLD_KEY = 2,
    GREEN_KEY = 1
}

public class KeysManager : MonoBehaviour
{
    private const string RED_KEY = "RED_KEY";
    private const string YELLOW_KEY = "YELLOW_KEY";
    private const string BLUE_KEY = "BLUE_KEY";
    private const string GREEN_KEY = "GREEN_KEY";

    public Text keysDisplay;
    private KEYS keys = 0;
    public KEYS Keys => keys;


    public void RemoveKey(KEYS key) {
        keys &= ~key;
    }
    void Update()
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(this.transform.position);
        keysDisplay.transform.position = screenPoint + new Vector3(0,-50,0);
        keysDisplay.text = Convert.ToString((int)keys, 2).PadLeft(8, '0');
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(BLUE_KEY)) {
            keys |= KEYS.BLUEKEY;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag(YELLOW_KEY))
        {
            keys |= (KEYS.GOLD_KEY | KEYS.BLUEKEY | KEYS.GREEN_KEY);
            Destroy(other.gameObject);
        }
      
        if (other.gameObject.CompareTag(GREEN_KEY))
        {
            keys |= KEYS.GREEN_KEY;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag(RED_KEY))
        {
            keys |= KEYS.REDKEY;
            Destroy(other.gameObject);
        }
    }

}
