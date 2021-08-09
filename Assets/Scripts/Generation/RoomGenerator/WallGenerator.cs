using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class WallGenerator
{
    private static TilemapPainter tilemapPainter = new TilemapPainter();
    private static List<Vector2Int> cardinalDirections = new List<Vector2Int> {
         Vector2Int.up,
         Vector2Int.down,
         Vector2Int.left,
         Vector2Int.right
    };

    public static void CreateWalls(HashSet<Vector2Int> floorPositions, Tilemap tilemap)
    {
        var cardinalWallPositions = FindWalls(floorPositions);

    }

    private static HashSet<Vector2Int> FindWalls(HashSet<Vector2Int> floorPositions)
    {
        HashSet<Vector2Int> wallPositions = new HashSet<Vector2Int>();

        foreach (var position in floorPositions)
        {
            foreach (var direction in cardinalDirections)
            {
                var neighborPosition = position + direction;
                if (!floorPositions.Contains(neighborPosition))
                {
                    wallPositions.Add(neighborPosition);
                }
            }
        }
        return wallPositions;
    }
}
