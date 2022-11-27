using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;
    public static class Pathfinding {
    private static readonly Color PathColor = new Color(0.65f, 0.35f, 0.35f);
    public static List<NodeBase> path = new List<NodeBase>();
    public static List<NodeBase> FindPath(NodeBase startNode, NodeBase targetNode) 
    {
        var search = new List<NodeBase>() 
        { 
            startNode 
        };
        var processed = new List<NodeBase>();

        while (search.Any()) {
            var current = search[0];
            foreach (var t in search) 
                if (t.F < current.F || t.F == current.F && t.H < current.H) current = t;

            processed.Add(current);
            search.Remove(current);

            if (current == targetNode) {
                var currentPathTile = targetNode;
                var count = 100;
                while (currentPathTile != startNode) {
                    path.Add(currentPathTile);
                    currentPathTile = currentPathTile.Connection;
                    count--;
                    if (count < 0) throw new Exception();
                }
                foreach (var tile in path) tile.SetColor(PathColor);
                startNode.SetColor(PathColor);
                path.Reverse();
                return path;
            }
            foreach (var neighbor in current.Neighbors.Where(t => t.Walkable && !processed.Contains(t))) {
                var inSearch = search.Contains(neighbor);

                var costToNeighbor = current.G + current.GetDistance(neighbor);

                if (!inSearch || costToNeighbor < neighbor.G) {
                    neighbor.SetG(costToNeighbor);
                    neighbor.SetConnection(current);

                    if (!inSearch) {
                        neighbor.SetH(neighbor.GetDistance(targetNode));
                        search.Add(neighbor);
                    }
                }
            }
        }
        return null;
    }
    }
