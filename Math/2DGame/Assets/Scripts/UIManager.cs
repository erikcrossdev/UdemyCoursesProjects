using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject tank;
    public GameObject fuel;
    public TextMeshProUGUI tankPosition;
    public TextMeshProUGUI fuelPosition;
    public TextMeshProUGUI energyAmount;
    public TMP_InputField inputField;

    public void AddEnergy() 
    {
        float number;
        if (float.TryParse(inputField.text, out number)) {
            energyAmount.text = inputField.text;
        }  
    }

    void Start()
    {
        tankPosition.text = tank.transform.position + "";
        fuelPosition.text = fuel.GetComponent<ObjectManager>().objectPosition + "";
    }

    void Update()
    {
        
    }
}
