using System.Collections.Generic;
using UnityEngine;
    public class ScriptableSquareGrid : ScriptableGrid
    {
        private int _gridWidth = 12;
        private int _gridHeight =12;
        public override Dictionary<Vector2, NodeBase> GenerateGrid() {
            var tiles = new Dictionary<Vector2, NodeBase>();
            var grid = new GameObject {
                name = "Grid"
            };
            for (int x = 0; x < _gridWidth; x++)
            {
                for (int y = 0; y < _gridHeight; y++)
                {
                    var tile = Instantiate(nodeBasePrefab, grid.transform);
                    tile.Init(DecideIfObstacle(), new SquareCoords { Pos = new Vector3(x, y) });
                    tiles.Add(new Vector2(x, y), tile);
                }
            }
            return tiles;
        }
    }
