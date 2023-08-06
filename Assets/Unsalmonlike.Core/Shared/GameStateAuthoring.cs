using Unity.Entities;
using UnityEngine;

namespace Unsalmonlike {
	public enum GameStateValue {
		Running,
		Loading,
		Paused,
	}

	public struct GameState : IComponentData {
		public GameStateValue Value;
	}

	public class GameStateAuthoring : MonoBehaviour { }

	public class GameStateBaker : Baker<GameStateAuthoring> {
		public override void Bake(GameStateAuthoring authoring) =>
			AddComponent(GetEntity(TransformUsageFlags.Dynamic), new GameState {
				Value = GameStateValue.Loading
			});
	}
}
