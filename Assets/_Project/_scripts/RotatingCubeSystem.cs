using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace LearningDots
{
    public partial struct RotatingCubeSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<RotateSpeed>();
        }
        
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            /*
            foreach (var (localTransform, rotateSpeed) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<RotateSpeed>>())
            {
                localTransform.ValueRW = localTransform.ValueRO.RotateY(rotateSpeed.ValueRO.value * SystemAPI.Time.DeltaTime);
            }
            */
            var rotatingCubeJob = new RotatingCubeJob
            {
                deltaTime = SystemAPI.Time.DeltaTime
            };
            rotatingCubeJob.Schedule();
        }
    }

    [BurstCompile]
    public partial struct RotatingCubeJob : IJobEntity
    {
        public float deltaTime;
        public void Execute(ref LocalTransform localTransform, in RotateSpeed rotateSpeed)
        {
            localTransform = localTransform.RotateY(rotateSpeed.value * deltaTime);
        }
    }
}