using Unity.Entities;
using UnityEngine;

namespace LearningDots
{
    public class BoxAuthoring : MonoBehaviour
    {
        
        public class Baker : Baker<BoxAuthoring>
        {
            public override void Bake(BoxAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new Box());
            }
        }
    }

    public struct Box : IComponentData { }
    
}