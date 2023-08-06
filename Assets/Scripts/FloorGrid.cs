using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Unsalmonlike {
	public class FloorGrid : MonoBehaviour {
		[SerializeField] private GameObject _tilePrefab;
		[SerializeField] private int _width;
		[SerializeField] private int _depth;
		private FloorTile[,] _tileGrid;

		private void Awake() {
			_tileGrid = new FloorTile[_width, _depth];
			int xOffset = (_width - 1) / 2;
			int zOffset = (_depth - 1) / 2;

			for (var z = 0; z < _depth; z++) {
				for (var x = 0; x < _width; x++) {
					var tile = Instantiate(_tilePrefab, transform);
					tile.transform.position = new Vector3(x - xOffset, 0, z - zOffset);
					_tileGrid[x, z] = tile.GetComponent<FloorTile>();

				}
			}
		}

		//private void Start() => _tileGrid[1, 7].StartCoroutine(_tileGrid[1, 7].TestOpenClose());
	}
}
