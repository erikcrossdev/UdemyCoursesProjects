using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plant : MonoBehaviour
{
    [SerializeField] private PlantData info;
    SetPlantInfo spi;

    private void Start()
    {
        spi = SetPlantInfo.instance;
    }

    private void OnMouseDown()
    {
        spi.OpenPlantPanel();
        spi.planeName.text = info.PlantName;
        spi.threatLevel.text = info.Threat.ToString();
        spi.plantIcon.GetComponent<RawImage>().texture = info.Icon;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && info.Threat == THREAT.High) {
            PlayerController.dead = true;
        }
    }
}
