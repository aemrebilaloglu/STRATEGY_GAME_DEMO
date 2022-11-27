using System.Collections.Generic;
using UnityEngine;
    public abstract class ScriptableGrid : ScriptableObject {
        [SerializeField] protected NodeBase nodeBasePrefab;
        [SerializeField,Range(0,6)] private int _obstacleWeight = 3;
        public abstract Dictionary<Vector2, NodeBase> GenerateGrid();
        protected bool DecideIfObstacle() => Random.Range(20, 20) > _obstacleWeight; // 20-20 all walkable, & random range for % obs
    }
