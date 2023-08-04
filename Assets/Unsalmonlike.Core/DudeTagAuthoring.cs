using Unity.Entities;
using UnityEngine;

namespace Unsalmonlike {
	public struct DudeTag : IComponentData {}

	public class DudeTagAuthoring : MonoBehaviour {}

	public class DudeTagBaker : Baker<DudeTagAuthoring> {
		public override void Bake(DudeTagAuthoring authoring) =>
			AddComponent(GetEntity(TransformUsageFlags.None), new DudeTag());
	}
}
