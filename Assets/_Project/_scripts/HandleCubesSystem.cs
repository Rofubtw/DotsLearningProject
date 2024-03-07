using Unity.Entities;

namespace LearningDots
{
    public partial struct HandleCubesSystem : ISystem
    {
        public void OnUpdate(ref SystemState state)
        {
            foreach (RotatingMovingCubeAspect rotatingMovingCubeAspect in SystemAPI
                         .Query<RotatingMovingCubeAspect>().WithAll<Box>()) 
            {
                rotatingMovingCubeAspect.MoveAndRotate(SystemAPI.Time.DeltaTime);
            }
        }
    }
}