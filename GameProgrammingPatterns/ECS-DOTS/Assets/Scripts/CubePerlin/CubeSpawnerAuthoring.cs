using Unity.Entities;
using UnityEngine;

public class CubeSpawnerAuthoring : MonoBehaviour
{
    public GameObject cubePrefab;

    class Baker : Baker<CubeSpawnerAuthoring>
    {
        public override void Bake(CubeSpawnerAuthoring authoring)
        {
            // Convert the GameObject prefab to an Entity prefab
            var prefabEntity = GetEntity(authoring.cubePrefab, TransformUsageFlags.Renderable);

            // Instead of AddComponent, use this method to add and set the component data
            var entity = GetEntity(TransformUsageFlags.Renderable);
            AddComponent(entity, new CubePrefabComponent { Prefab = prefabEntity });
        }
    }
}