using System.Collections.Generic;
using System.Linq;
using _Scripts.Tiles;
using Tarodev_Pathfinding._Scripts.Grid.Scriptables;
using Tarodev_Pathfinding._Scripts.Units;
using UnityEngine;
using DG.Tweening;
using System.Collections;
using Random = UnityEngine.Random;

namespace Tarodev_Pathfinding._Scripts.Grid {
    public class GridManager : MonoBehaviour {
        public static GridManager Instance;

        [SerializeField] private Sprite _playerSprite, _goalSprite;
        [SerializeField] private Unit _unitPrefab;
        [SerializeField] private ScriptableGrid _scriptableGrid;
        [SerializeField] private bool _drawConnections;

        public Dictionary<Vector2, NodeBase> Tiles { get; private set; }

        private NodeBase _playerNodeBase, _goalNodeBase;
        private Unit _spawnedPlayer, _spawnedGoal;

        void Awake() => Instance = this;

        private void Start() {
            Tiles = _scriptableGrid.GenerateGrid();
         
            foreach (var tile in Tiles.Values) tile.CacheNeighbors();

            SpawnUnits();
            NodeBase.OnHoverTile += OnTileHover;
        }

        private void OnDestroy() => NodeBase.OnHoverTile -= OnTileHover;
        public bool isTarget = false;
        private void OnTileHover(NodeBase nodeBase) {
            _goalNodeBase = nodeBase;
            if (!isTarget)
            {
                _playerNodeBase = nodeBase;
                _spawnedPlayer.transform.position = _goalNodeBase.Coords.Pos;
            }
            else
            {
                _spawnedGoal.transform.position = _goalNodeBase.Coords.Pos;
            }

            foreach (var t in Tiles.Values) t.RevertTile();
            var path = Pathfinding.FindPath(_playerNodeBase, _goalNodeBase);
            if (isTarget)
            {
                StartCoroutine(DelayMoveToPath());

                IEnumerator DelayMoveToPath()
                {
                    for (int i = 0; i < Pathfinding.path.Count; i++)
                    {
                        _spawnedPlayer.transform.DOMove(Pathfinding.path[i].transform.position, 0.25f);

                        yield return new WaitForSeconds(0.25f);
                    }

                    _playerNodeBase = nodeBase;
                    _spawnedPlayer.transform.position = _goalNodeBase.Coords.Pos;
                    path.Clear();
                }
            }
        }

        public void SpawnUnits() {
            //_playerNodeBase = Tiles.Where(t => t.Value.Walkable).OrderBy(t => Random.value).First().Value;
            _spawnedPlayer = Instantiate(_unitPrefab, new Vector3(50, 50, 50), Quaternion.identity);
            _spawnedPlayer.Init(_playerSprite);

            _spawnedGoal = Instantiate(_unitPrefab, new Vector3(50, 50, 50), Quaternion.identity);
            _spawnedGoal.Init(_goalSprite);
        }

        public NodeBase GetTileAtPosition(Vector2 pos) => Tiles.TryGetValue(pos, out var tile) ? tile : null;

        private void OnDrawGizmos() {
            if (!Application.isPlaying || !_drawConnections) return;
            Gizmos.color = Color.red;
            foreach (var tile in Tiles) {
                if (tile.Value.Connection == null) continue;
                Gizmos.DrawLine((Vector3)tile.Key + new Vector3(0, 0, -1), (Vector3)tile.Value.Connection.Coords.Pos + new Vector3(0, 0, -1));
            }
        }
    }
}