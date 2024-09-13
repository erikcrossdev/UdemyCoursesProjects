using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Flags]
public enum ATTRIBUTES {
    MAGIC = 16,
    INTELLIGENCE = 8,
    CHARISMA = 4,
    FLY = 2,
    INVISIBLE = 1
}

public class AttributeManager : MonoBehaviour
{
    private const string MAGIC = "MAGIC";
    private const string ADD_MULT = "ADD_MULT";
    private const string REMOVE_MULT = "REMOVE_MULT";
    private const string MAGIC_REMOVE = "MAGIC_REMOVE";
    private const string CHARISMA = "CHARISMA";
    private const string FLY = "FLY";
    private const string INTELLIGENCE = "INTELLIGENCE";
    private const string INVISIBLE = "INVISIBLE";
    private const string WIPE = "WIPE";
    public Text attributeDisplay;
    private ATTRIBUTES attributes = 0;
    public ATTRIBUTES Attributes => attributes;

   
    void Update()
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(this.transform.position);
        attributeDisplay.transform.position = screenPoint + new Vector3(0,-50,0);
        attributeDisplay.text = Convert.ToString((int)attributes, 2).PadLeft(8, '0');
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(MAGIC)) {
            attributes |= ATTRIBUTES.MAGIC;
        }
        if (other.gameObject.CompareTag(INTELLIGENCE))
        {
            attributes |= ATTRIBUTES.INTELLIGENCE;
        }
        if (other.gameObject.CompareTag(FLY))
        {
            attributes |= ATTRIBUTES.FLY;
        }
        if (other.gameObject.CompareTag(CHARISMA))
        {
            attributes |= ATTRIBUTES.CHARISMA;
        }
        if (other.gameObject.CompareTag(INVISIBLE))
        {
            attributes |= ATTRIBUTES.INVISIBLE;
        }
        if (other.gameObject.CompareTag(MAGIC_REMOVE))
        {
            attributes &= ~ATTRIBUTES.MAGIC;
        }
        if (other.gameObject.CompareTag(ADD_MULT))
        {
            attributes |= (ATTRIBUTES.INTELLIGENCE | ATTRIBUTES.MAGIC | ATTRIBUTES.CHARISMA);
        }
        if (other.gameObject.CompareTag(REMOVE_MULT))
        {
            attributes &= ~( ATTRIBUTES.MAGIC | ATTRIBUTES.INTELLIGENCE); ;
        }
        if (other.gameObject.CompareTag(WIPE))
        {
            attributes = 0;
            //attributes &= ~(ATTRIBUTES.MAGIC | ATTRIBUTES.INTELLIGENCE | ATTRIBUTES.CHARISMA | ATTRIBUTES.FLY | ATTRIBUTES.INVISIBLE);
        }
    }

}
