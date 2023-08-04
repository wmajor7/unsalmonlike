using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Unsalmonlike {
	public struct TargetPosition : IComponentData {
		public float3 Value;
	}

	public class TargetPositionAuthoring : MonoBehaviour {
		public float3 Value;
	}

	public class TargetPositionBaker : Baker<TargetPositionAuthoring> {
		public override void Bake(TargetPositionAuthoring authoring) =>
			AddComponent(GetEntity(TransformUsageFlags.Dynamic), new TargetPosition {
				Value = authoring.Value
			});
	}
}
