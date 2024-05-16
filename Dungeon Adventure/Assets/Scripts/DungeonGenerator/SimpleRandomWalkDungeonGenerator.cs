// Zachary Anderson

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SimpleRandomWalkDungeonGenerator : AbstractDungeonGenerator
{
    [SerializeField]    // Exposes in the editor
    private int iterations = 10;
    [SerializeField]    // Allows to be seen in the inspector
    public int walkLength = 10;
    [SerializeField]
    public bool startRandomlyEachIteration = true;

    protected override void RunProceduralGeneration() {
        HashSet<Vector2Int> floorPositions = RunRandomWalk(startPosition);
        tilemapVisualizer.Clear();
        tilemapVisualizer.PaintFloorTiles(floorPositions);
        WallGenerator.CreateWalls(floorPositions, tilemapVisualizer);
        foreach (var position in floorPositions) {
            Debug.Log(position);
        }
    }

    protected HashSet<Vector2Int> RunRandomWalk(Vector2Int position) {
        var currentPosition = position;
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        for (int i = 0; i < iterations; i++) {
            var path = ProceduralGenerationAlgorithms.SimpleRandomWalk(currentPosition, walkLength);
            floorPositions.UnionWith(path);
            if (startRandomlyEachIteration) {
                currentPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
            }
        }
        return floorPositions;
    }

}
