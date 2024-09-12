using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
/*
public partial class CubeSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = SystemAPI.Time.DeltaTime;
        //RefRO stands for reference read only, is for parameters that we are going just to read
        //RefRW stands for read and write, for parameters that we are going to write and read
        foreach(var (cubeData, transform) in SystemAPI.Query<RefRO<CubeData>, RefRW<LocalTransform>>()) //access the transform and cube data
        {
            transform.ValueRW = transform.ValueRO.RotateY(math.radians(cubeData.ValueRO.speed * deltaTime));
        }
    }
}*/

public partial struct CubeSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        var job = new CubeJob {
            deltaTime = SystemAPI.Time.DeltaTime,

        };
        job.ScheduleParallel();

    }
}

public partial struct CubeJob : IJobEntity
{
    public float deltaTime;
    public void Execute(ref CubeData cubedata, ref LocalTransform transform) {
        transform = transform.RotateY(math.radians(cubedata.speed * deltaTime));
    }
}