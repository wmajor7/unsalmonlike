using Unity.Entities;
using UnityEngine;

namespace Unsalmonlike {
	public struct RandomComponent : IComponentData {
		public Unity.Mathematics.Random Rnd;
	}

	public class RandomComponentAuthoring : MonoBehaviour {}

	public class RandomComponentBaker : Baker<RandomComponentAuthoring> {
		public override void Bake(RandomComponentAuthoring authoring) =>
			AddComponent(GetEntity(TransformUsageFlags.Dynamic), new RandomComponent {
				Rnd = new Unity.Mathematics.Random(1)
			});
	}
}
