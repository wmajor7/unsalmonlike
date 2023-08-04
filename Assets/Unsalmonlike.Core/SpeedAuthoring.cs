using Unity.Entities;
using UnityEngine;

namespace Unsalmonlike {
	public struct Speed : IComponentData {
		public float Value;
	}

	public class SpeedAuthoring : MonoBehaviour {
		public float Value;
	}

	public class SpeedBaker : Baker<SpeedAuthoring> {
		public override void Bake(SpeedAuthoring authoring) =>
			AddComponent(GetEntity(TransformUsageFlags.Dynamic), new Speed {
				Value = authoring.Value
			});
	}
}
