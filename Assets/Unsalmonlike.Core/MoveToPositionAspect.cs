using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Unsalmonlike {
	public readonly partial struct MoveToPositionAspect : IAspect {
		private readonly Entity entity;
		private readonly RefRW<LocalTransform> localTransform;
		private readonly RefRO<Speed> speed;
		private readonly RefRW<TargetPosition> targetPosition;

		public void Move(float deltaTime) {
			float3 direction = math.normalize(targetPosition.ValueRW.Value - localTransform.ValueRO.Position);
			localTransform.ValueRW.Position += direction * deltaTime * speed.ValueRO.Value;
		}

		public void TestReachedTargetPosition(RefRW<RandomComponent> rnd) {
			float reachedTargetDistance = .5f;
			if (math.distance(localTransform.ValueRO.Position, targetPosition.ValueRW.Value) < reachedTargetDistance) {
				targetPosition.ValueRW.Value = GetRandomPosition(rnd);
			}
		}

		private float3 GetRandomPosition(RefRW<RandomComponent> rnd) => new(
			rnd.ValueRW.Rnd.NextFloat(0, 15),
			0,
			rnd.ValueRW.Rnd.NextFloat(0, 15)
		);
	}

	//internal static class Util {
	//	internal static readonly Unity.Mathematics.Random Random = new(1);
	//}
}
