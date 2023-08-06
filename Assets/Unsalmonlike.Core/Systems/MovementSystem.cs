using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;

namespace Unsalmonlike {
	public partial struct MovementSystem : ISystem {
		[BurstCompile]
		void ISystem.OnUpdate(ref SystemState state) {
			var gameState = SystemAPI.GetSingleton<GameState>();
			var randomComponent = SystemAPI.GetSingletonRW<RandomComponent>();
			var deltaTime = SystemAPI.Time.DeltaTime;

			if (gameState.Value != GameStateValue.Running) return;

			new MoveJob() {
				deltaTime = deltaTime
			}.ScheduleParallel(state.Dependency)
			.Complete();

			new TestReachedTargetPositionJob() {
				randomComponent = randomComponent
			}.Run();
		}
	}

	[BurstCompile]
	public partial struct MoveJob : IJobEntity {
		public float deltaTime;

		[BurstCompile]
		public void Execute(MoveToPositionAspect moveToPositionAspect) =>
			moveToPositionAspect.Move(deltaTime);
	}

	[BurstCompile]
	public partial struct TestReachedTargetPositionJob : IJobEntity {
		[NativeDisableUnsafePtrRestriction] public RefRW<RandomComponent> randomComponent;

		[BurstCompile]
		public void Execute(MoveToPositionAspect moveToPositionAspect) =>
			moveToPositionAspect.TestReachedTargetPosition(randomComponent);
	}
}
