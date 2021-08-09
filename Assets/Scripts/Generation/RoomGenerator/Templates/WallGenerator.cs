using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Gets the wall positions based on the floor layout. Can be used by any template to get appropriate
/// wall positions.
/// </summary>
public static class WallGenerator
{
    private static List<Vector2Int> cardinalDirections = new List<Vector2Int> {
         Vector2Int.up,
         Vector2Int.down,
         Vector2Int.left,
         Vector2Int.right
    };

    public static HashSet<Vector2Int> GetWalls(HashSet<Vector2Int> floorPositions)
    {
        var cardinalWallPositions = FindCardinalWalls(floorPositions);

        return cardinalWallPositions;
    }

    private static HashSet<Vector2Int> FindCardinalWalls(HashSet<Vector2Int> floorPositions)
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
