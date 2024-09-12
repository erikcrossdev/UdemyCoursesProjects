using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public sealed class GameEnvironment 
{
    private static GameEnvironment instance;
    private List<GameObject> checkpoints = new List<GameObject>();
    public List<GameObject> Checkpoints => checkpoints;
    private GameObject safeLocation;
    public GameObject SafeLocation => safeLocation;
    public static GameEnvironment Singleton {
        get {
            if (instance == null)
            {
                instance = new GameEnvironment();

                instance.safeLocation = GameObject.FindGameObjectWithTag("Safe");

                //instance.Checkpoints.AddRange(GameObject.FindGameObjectsWithTag("Checkpoint"));

                //instance.checkpoints = instance.checkpoints.OrderBy(waypoint =>waypoint.name).ToList();
            }
            return instance;
        }
    }

    public void AddCheckpoint(GameObject point) {
        instance.Checkpoints.Add(point);
    }

    public void OrderList()
    {
        instance.checkpoints = instance.checkpoints.OrderBy(waypoint => waypoint.name).ToList();
    }
}
