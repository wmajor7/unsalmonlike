using Unity.Entities;
using UnityEngine;

namespace Unsalmonlike {
	public struct PlayerTag : IComponentData {}

	public class PlayerTagAuthoring : MonoBehaviour {}

	public class PlayerTagBaker : Baker<PlayerTagAuthoring> {
		public override void Bake(PlayerTagAuthoring authoring) =>
			AddComponent(GetEntity(TransformUsageFlags.None), new PlayerTag());
	}
}
