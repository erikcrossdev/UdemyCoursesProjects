using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCheckpointToList : MonoBehaviour
{
    private void Awake()
    {
        GameEnvironment.Singleton.AddCheckpoint(this.gameObject);
    }
}
