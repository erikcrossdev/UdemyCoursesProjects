using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject tank;
    public ObjectManager fuel;
    public TextMeshProUGUI tankPosition;
    public TextMeshProUGUI fuelPosition;

    void Start()
    {
        tankPosition.text = tank.transform.position + "";
        fuelPosition.text = fuel.objectPosition + "";
    }

    void Update()
    {
        
    }
}
