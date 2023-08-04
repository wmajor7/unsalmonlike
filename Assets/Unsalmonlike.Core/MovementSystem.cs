using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace Unsalmonlike {
	public partial struct MovementSystem : ISystem {
		void ISystem.OnUpdate(ref Unity.Entities.SystemState state) {
			//var randomComponent = SystemAPI.GetSingletonRW<RandomComponent>();

			//foreach (var moveToPositionAspect in SystemAPI.Query<MoveToPositionAspect>()) {
			//	moveToPositionAspect.Move(SystemAPI.Time.DeltaTime, randomComponent);
			//}
		}
	}
}
