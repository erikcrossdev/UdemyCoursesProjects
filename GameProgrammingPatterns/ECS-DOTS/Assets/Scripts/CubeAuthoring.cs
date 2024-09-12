using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class CubeAuthoring : MonoBehaviour
{
    public float speed = 100;

    public class CubeBaker : Baker<CubeAuthoring>
    {
        public override void Bake(CubeAuthoring authoring)  //Bake the entity to the data
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic); //get the entity
            AddComponent(entity, new CubeData { //Syas that the data is Cube data
                    speed =authoring.speed,   //set the speed to CubeAuthoring speed
            }); 
        }
    }
}
