using Unity.Burst;
using Unity.Entities;

namespace Unsalmonlike {
	public partial struct DudeSpawnerSystem : ISystem {
		[BurstCompile]
		void ISystem.OnUpdate(ref SystemState state) {
			var dudeQuery = SystemAPI.QueryBuilder().WithAll<DudeTag>().Build();
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
