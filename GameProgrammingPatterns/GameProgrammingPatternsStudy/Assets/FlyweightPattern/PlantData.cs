using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum THREAT { None, Low, Moderate, High }

[CreateAssetMenu(fileName ="PlantData", menuName = "Plant Data", order = 51)]
public class PlantData : ScriptableObject
{
    [SerializeField] private string plantName;
    [SerializeField] private THREAT plantThreat;
    [SerializeField] private Texture icon;

    public string PlantName => plantName;
    public THREAT Threat => plantThreat;
    public Texture Icon => icon;
}
