using System;
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
    // The total additional tiles to be placed in each direction beyond the room
    // size. An overrun of 6 will create 3 additional tiles on each side (half 
    // above, half below).
    [SerializeField]
    private static int overrunVertical = 6;

    [SerializeField]
    private static int overrunHorizontal = 10;


    private static List<Vector2Int> cardinalDirections = new List<Vector2Int> {
         Vector2Int.up,
         Vector2Int.down,
         Vector2Int.left,
         Vector2Int.right
    };

    public static HashSet<Vector2Int> GetWalls(HashSet<Vector2Int> nonWallPositions, int roomHeight, int roomWidth)
    {
        int wallPositionsHeight = roomHeight + overrunVertical;
        int wallPositionsWidth = roomWidth + overrunHorizontal;

        HashSet<Vector2Int> wallPositions = GetRectangularWallPositions(nonWallPositions, wallPositionsHeight, wallPositionsWidth);
        
        return wallPositions;
    }

    private static HashSet<Vector2Int> GetRectangularWallPositions(HashSet<Vector2Int> nonWallPositions, int wallPositionsHeight, int wallPositionsWidth)
    {
        // Fill the viewing area. 
        HashSet<Vector2Int> wallPositions = TemplateHelpers.FillRectangularCoordinates(wallPositionsHeight, wallPositionsWidth);

        // Then remove every position that is a position of something not a wall (floor, pit, etc.)
        wallPositions.RemoveWhere(nonWallPositions.Contains);
        
        return wallPositions;
    }

    // Currently unused.
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
