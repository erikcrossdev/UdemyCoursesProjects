using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;  // Make sure this namespace is included
using UnityEngine;

[BurstCompile]
public partial struct CubeSpawnerSystem : ISystem
{
    public void OnCreate(ref SystemState state)
    {
        // System initialization
    }

    public void OnUpdate(ref SystemState state)
    {
        int width = 100;
        int depth = 100;
        float scale = 0.21f;

        var entityManager = state.EntityManager;
        var cubePrefabQuery = SystemAPI.QueryBuilder().WithAll<CubePrefabComponent>().Build();
        var cubePrefabComponent = cubePrefabQuery.GetSingleton<CubePrefabComponent>();
        Entity cubePrefab = cubePrefabComponent.Prefab;

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < depth; z++)
            {
                float y = Mathf.PerlinNoise(x * scale, z * scale);

                Entity cubeEntity = entityManager.Instantiate(cubePrefab);

                // Set the position and scale using LocalTransform
                entityManager.SetComponentData(cubeEntity, LocalTransform.FromPosition(new float3(x, y, z)));
            }
        }

        state.Enabled = false; // Disable the system after generating the terrain
    }

    public void OnDestroy(ref SystemState state)
    {
        // System cleanup
    }
}