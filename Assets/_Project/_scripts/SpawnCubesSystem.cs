using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace LearningDots
{
    public partial class SpawnCubesSystem : SystemBase
    {
        protected override void OnCreate()
        {
            RequireForUpdate<SpawnCubesConfig>();
        }
        protected override void OnUpdate()
        {
            this.Enabled = false;
            
            // If you have zero or more than one SpawnCubesConfig in scene this line cause an error.
            var spawnCubesConfig = SystemAPI.GetSingleton<SpawnCubesConfig>(); 

            for (var i = 0; i < spawnCubesConfig.amountToSpawn; i++)
            {
                var spawnedEntity = EntityManager.Instantiate(spawnCubesConfig.cubePrefabEntity);
                EntityManager.SetComponentData(spawnedEntity, new LocalTransform
                {
                    Position = new float3(UnityEngine.Random.Range(-10f, 5f), 0.6f, UnityEngine.Random.Range(-4f, 7f)),
                    Rotation = quaternion.identity,
                    Scale = 1
                });
                // LocalTransform.FromPosition(new float3(UnityEngine.Random.Range(-10f, 5f), 0.6f,
                //     UnityEngine.Random.Range(-4f, 7f)));
            }
        }
    }
}