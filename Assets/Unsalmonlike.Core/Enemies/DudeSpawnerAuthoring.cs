using Unity.Entities;
using UnityEngine;

namespace Unsalmonlike {
	public struct DudeSpawner : IComponentData {
		public Entity Prefab;
	}

	public class DudeSpawnerAuthoring : MonoBehaviour {
		public GameObject Prefab;
	}

	public class DudeSpawnerBaker : Baker<DudeSpawnerAuthoring> {
		public override void Bake(DudeSpawnerAuthoring authoring) =>
			AddComponent(GetEntity(TransformUsageFlags.Dynamic), new DudeSpawner {
				Prefab = GetEntity(authoring.Prefab, TransformUsageFlags.None)
			});
	}
}
