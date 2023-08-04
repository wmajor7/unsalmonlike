using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

namespace Unsalmonlike {
	public class SpeedAuthoring : MonoBehaviour {
		public float Value;
	}
	public class SpeedBaker : Baker<SpeedAuthoring> {
		public override void Bake(SpeedAuthoring authoring) {
			AddComponent(GetEntity(authoring, TransformUsageFlags.Dynamic), new Speed {
				Value = authoring.Value
			});
		}
	}
}
