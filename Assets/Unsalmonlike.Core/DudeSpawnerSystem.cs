using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using UnityEngine;

namespace Unsalmonlike {
	public partial struct DudeSpawnerSystem : ISystem {
		[BurstCompile]
		void ISystem.OnUpdate(ref SystemState state) {
			var dudeQuery = state.EntityManager.CreateEntityQuery(typeof(DudeTag));
			//var dudeQuery = SystemAPI.Query<DudeTag>();
			var spawner = SystemAPI.GetSingleton<DudeSpawner>();

			var spawnAmount = 300;

			if (dudeQuery.CalculateEntityCount() < spawnAmount) {
				state.EntityManager.Instantiate(spawner.Prefab);
			}
		}
	}
	[BurstCompile]
	public partial struct DoNothingJob : IJobEntity {
		public float deltaTime;

		[BurstCompile]
		public void Execute(MoveToPositionAspect moveToPositionAspect) =>
			moveToPositionAspect.Move(deltaTime);
	}
}
