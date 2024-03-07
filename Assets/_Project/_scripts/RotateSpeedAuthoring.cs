using Unity.Entities;
using UnityEngine;

namespace LearningDots
{
    public class RotateSpeedAuthoring : MonoBehaviour
    {
        public float value;

        public class Baker : Baker<RotateSpeedAuthoring>
        {
            public override void Bake(RotateSpeedAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new RotateSpeed { value = authoring.value });
            }
        }
    }

    public struct RotateSpeed: IComponentData
    {
        public float value;
    }
}

