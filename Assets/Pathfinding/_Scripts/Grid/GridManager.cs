using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;
using System.Collections;
    public class GridManager : MonoBehaviour {
    public static GridManager Instance;
    [SerializeField] private Sprite _playerSprite;
    [SerializeField] private Unit _unitPrefab;
    [SerializeField] private ScriptableGrid _scriptableGrid;
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
            if (path.Count < 1)return;
            StartCoroutine(DelayMoveToPath());
            IEnumerator DelayMoveToPath()
            {
                BarracksManager.instance.onMove = true;
                for (int i = 0; i < Pathfinding.path.Count; i++)
                {
                    _spawnedPlayer.transform.DOMove(Pathfinding.path[i].transform.position, 0.25f);

                    yield return new WaitForSeconds(0.25f);
                }
                if (BarracksManager.instance.SoldierUnit.transform.childCount > 1)
                {
                    BarracksManager.instance.SoldierUnit.transform.GetChild(1).parent = null;
                }

                BarracksManager.instance.soldierMove = false;
                BarracksManager.instance.onMove = false;

                _playerNodeBase = nodeBase;
                _spawnedPlayer.transform.position = _goalNodeBase.Coords.Pos;
                path.Clear();
            }
        }
    }
    public void SpawnUnits()
    {
        _spawnedPlayer = Instantiate(_unitPrefab, new Vector3(50, 50, 50), Quaternion.identity);
        _spawnedPlayer.Init(_playerSprite);
        BarracksManager.instance.SoldierUnit = _spawnedPlayer;
        _spawnedGoal = Instantiate(_unitPrefab, new Vector3(50, 50, 50), Quaternion.identity);
    }
    public NodeBase GetTileAtPosition(Vector2 pos) => Tiles.TryGetValue(pos, out var tile) ? tile : null;
}
