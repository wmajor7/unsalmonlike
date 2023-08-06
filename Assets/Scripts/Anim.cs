using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unsalmonlike {
	public static class Anim {
		public static class Ease {
			private const float c1 = 1.70158f;
			private const float c2 = c1 * 1.525f;
			private const float c3 = c1 + 1;
			private const float c4 = (2 * Mathf.PI) / 3f;
			private const float c5 = (2 * Mathf.PI) / 4.5f;
			private const float n1 = 7.5625f;
			private const float d1 = 2.75f;
			public static class Sine {
				public static float In(float x) => 1 - Mathf.Cos((x * Mathf.PI) / 2);
				public static float Out(float x) => Mathf.Sin((x * Mathf.PI) / 2);
				public static float InOut(float x) => -(Mathf.Cos(Mathf.PI * x) - 1) / 2;
			}
			public static class Quad {
				public static float In(float x) => x * x;
				public static float Out(float x) => 1 - (1 - x) * (1 - x);
				public static float InOut(float x) => x < 0.5 ? 2 * x * x : 1 - Mathf.Pow(-2 * x + 2, 2) / 2;
			}
			public static class Cubic {
				public static float In(float x) => x * x * x;
				public static float Out(float x) => 1 - Mathf.Pow(1 - x, 3);
				public static float InOut(float x) => x < 0.5 ? 4 * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 3) / 2;
			}
			public static class Quart {
				public static float In(float x) => x * x * x * x;
				public static float Out(float x) => 1 - Mathf.Pow(1 - x, 4);
				public static float InOut(float x) => x < 0.5 ? 8 * x * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 4) / 2;
			}
			public static class Quint {
				public static float In(float x) => x * x * x * x * x;
				public static float Out(float x) => 1 - Mathf.Pow(1 - x, 5);
				public static float InOut(float x) => x < 0.5 ? 16 * x * x * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 5) / 2;
			}
			public static class Expo {
				public static float In(float x) => x <= 0 ? 0 : Mathf.Pow(2, 10 * x - 10);
				public static float Out(float x) => x >= 1 ? 1 : 1 - Mathf.Pow(2, -10 * x);
				public static float InOut(float x) => x <= 0 ? 0 : x >= 1 ? 1 : x < 0.5 ? Mathf.Pow(2, 20 * x - 10) / 2 : (2 - Mathf.Pow(2, -20 * x + 10)) / 2;
			}
			public static class Circ {
				public static float In(float x) => 1 - Mathf.Sqrt(1 - Mathf.Pow(x, 2));
				public static float Out(float x) => Mathf.Sqrt(1 - Mathf.Pow(x - 1, 2));
				public static float InOut(float x) => x < 0.5 ? (1 - Mathf.Sqrt(1 - Mathf.Pow(2 * x, 2))) / 2 : (Mathf.Sqrt(1 - Mathf.Pow(-2 * x + 2, 2)) + 1) / 2;
			}
			public static class Back {
				public static float In(float x) => c3 * x * x * x - c1 * x * x;
				public static float Out(float x) => 1 + c3 * Mathf.Pow(x - 1, 3) + c1 * Mathf.Pow(x - 1, 2);
				public static float InOut(float x) => x < 0.5 ? (Mathf.Pow(2 * x, 2) * ((c2 + 1) * 2 * x - c2)) / 2 : (Mathf.Pow(2 * x - 2, 2) * ((c2 + 1) * (x * 2 - 2) + c2) + 2) / 2;
			}
			public static class Elastic {
				public static float In(float x) => x <= 0 ? 0 : x >= 1 ? 1 : -Mathf.Pow(2, 10 * x - 10) * Mathf.Sin((x * 10 - 10.75f) * c4);
				public static float Out(float x) => x <= 0 ? 0 : x >= 1 ? 1 : Mathf.Pow(2, -10 * x) * Mathf.Sin((x * 5 - 0.75f) * c4) + 1; //modified: 10 changed to 5
				public static float InOut(float x) => x <= 0 ? 0 : x >= 1 ? 1 : x < 0.5 ? -(Mathf.Pow(2, 20 * x - 10) * Mathf.Sin((20 * x - 11.125f) * c5)) / 2 : (Mathf.Pow(2, -20 * x + 10) * Mathf.Sin((20 * x - 11.125f) * c5)) / 2 + 1;
			}
			public static class Bounce {
				public static float In(float x) => 1 - Out(1 - x);
				public static float Out(float x) => x < 1 / d1 ? n1 * x * x : x < 2 / d1 ? n1 * (x -= 1.5f / d1) * x + 0.75f : x < 2.5 / d1 ? n1 * (x -= 2.25f / d1) * x + 0.9375f : n1 * (x -= 2.625f / d1) * x + 0.984375f;
				public static float InOut(float x) => x < 0.5 ? (1 - Out(1 - 2 * x)) / 2 : (1 + Out(2 * x - 1)) / 2;
			}
		}

		private static YieldInstruction YieldNull = null;
		private static YieldInstruction EndOfFrame = new WaitForEndOfFrame();

		private static Vector3 RoundVector(Vector3 v) => new Vector3(Mathf.Round(v.x), Mathf.Round(v.y), Mathf.Round(v.z));
		private static Quaternion RoundQuaternion(Quaternion q, float angleInc = 90) => Quaternion.AngleAxis(Mathf.Round(q.eulerAngles.y / angleInc) * angleInc, Vector3.up);
		public static IEnumerable<int> Repeat(int n) {
			for (var i = 0; i < n; i++) yield return i;
		}

		//TODO: Vector3.Lerp clamps at 0,1
		public static IEnumerator MoveOffsetLerp(Transform t, float duration, Vector3 offset, Func<float, float>? easing = null) {
			var origin = t.position;
			var dest = origin + offset;

			var timespan = 0f;

			while (timespan < duration) {
				var timeRatio = timespan / duration;
				t.position = Vector3.Lerp(origin, dest, easing is null ? timeRatio : easing(timeRatio));
				timespan += Time.deltaTime;
				yield return YieldNull;
			}
			t.position = dest;
		}
		//TODO: Vector3.Lerp clamps at 0,1

		//TODO: use rb.position and rb.rotation

		public static IEnumerator MoveForwardLerp(Rigidbody rb, float duration, float dist, Func<float, float>? easing = null) {
			var origin = rb.transform.position;
			var dest = origin + rb.transform.forward * dist;

			var timespan = 0f;

			while (timespan < duration) {
				var timeRatio = timespan / duration;
				rb.MovePosition(Vector3.Lerp(origin, dest, easing is null ? timeRatio : easing(timeRatio)));
				timespan += Time.deltaTime;
				yield return YieldNull;
			}
			rb.MovePosition(dest);
		}
		public static IEnumerator MoveForward(Rigidbody rb, float duration, float dist, Func<float, float>? easing = null) {
			var origin = rb.transform.position;
			var offset = rb.transform.forward * dist;
			var dest = origin + offset;

			var timespan = 0f;

			while (timespan < duration) {
				var timeRatio = timespan / duration;
				rb.MovePosition(origin + offset * (easing is null ? timeRatio : easing(timeRatio)));
				timespan += Time.deltaTime;
				yield return YieldNull;
			}
			rb.MovePosition(dest);
		}

		//TODO: Quaternion.Lerp clamps at 0,1
		public static IEnumerator RotateYQuaternion(Rigidbody rb, float duration, float angle, float angleRound, Func<float, float>? easing = null) {
			var origin = rb.transform.rotation;
			var dest = RoundQuaternion(origin * Quaternion.AngleAxis(angle, Vector3.up), angleRound);

			var timespan = 0f;

			while (timespan < duration) {
				var timeRatio = timespan / duration;
				rb.MoveRotation(Quaternion.Lerp(origin, dest, easing is null ? timeRatio : easing(timeRatio)));
				//rb.transform.rotation = Quaternion.Lerp(origin, dest, easing is null ? timeRatio : easing(timeRatio));
				timespan += Time.deltaTime;
				yield return YieldNull;
			}
			rb.transform.rotation = dest;//rb.MoveRotation(dest); //MoveRotation isn't precise!
		}
		public static IEnumerator RotateYEuler(Rigidbody rb, float duration, float angle, float angleRound, Func<float, float>? easing = null) {
			var origin = rb.transform.rotation.eulerAngles.y;
			var dest = origin + angle; //RoundQuaternion(origin * Quaternion.AngleAxis(angle, Vector3.up), angleRound);


			var timespan = 0f;

			while (timespan < duration) {
				var timeRatio = timespan / duration;
				//rb.MoveRotation(Quaternion.Lerp(origin, dest, easing is null ? timeRatio : easing(timeRatio)));
				rb.MoveRotation(Quaternion.Euler(0, origin + angle * (easing is null ? timeRatio : easing(timeRatio)), 0));
				//rb.transform.rotation = Quaternion.Lerp(origin, dest, easing is null ? timeRatio : easing(timeRatio));
				timespan += Time.deltaTime;
				yield return YieldNull;
			}
			rb.transform.rotation = Quaternion.Euler(0, origin + angle, 0);//rb.MoveRotation(dest); //MoveRotation isn't precise!
		}
		public static IEnumerator Scale(Transform t, float duration, Vector3 newScale, Func<float, float>? easing = null) {
			var oldScale = t.localScale;
			var offset = newScale - oldScale;
			var timespan = 0f;

			while (timespan < duration) {
				var timeRatio = timespan / duration;
				t.localScale = oldScale + offset * (easing is null ? timeRatio : easing(timeRatio));
				timespan += Time.deltaTime;
				yield return null;
			}
			t.localScale = newScale;
		}
	}
}
