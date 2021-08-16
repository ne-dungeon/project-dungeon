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
    // The overrun "blank" tiles to be placed outside the walls, on each side. (Doubled in the function)
    [SerializeField]
    private static int overrunVertical = 3;
    [SerializeField]
    private static int overrunHorizontal = 5;

    // The width of the wall graphics in tiles. 
    // [SerializeField]
    // private static int wallWidth = 1;


    private static List<Vector2Int> cardinalDirections = new List<Vector2Int> {
         Vector2Int.up,
         Vector2Int.down,
         Vector2Int.left,
         Vector2Int.right
    };

    // Gets the positions of walls of specified width surrounding the room.
    public static HashSet<Vector2Int> GetWalls(HashSet<Vector2Int> nonWallPositions, int roomHeight, int roomWidth)
    {
        int wallPositionsHeight = roomHeight + (overrunVertical * 2);
        int wallPositionsWidth = roomWidth + (overrunHorizontal * 2);
        // int wallPositionsHeight = roomHeight + (wallWidth * 2);
        // int wallPositionsWidth = roomWidth + (wallWidth * 2);

        HashSet<Vector2Int> wallPositions = GetRectangularWallPositions(nonWallPositions, wallPositionsHeight, wallPositionsWidth);
        
        return wallPositions;
    }

    // Gets the positions to fill with blank space override tiles.
    // internal static HashSet<Vector2Int> GetWallOverrides(HashSet<Vector2Int> gameSceneTiles, int roomHeight, int roomWidth)
    // {
    //     int wallPositionsHeight = roomHeight + (overrunVertical * 2);
    //     int wallPositionsWidth = roomWidth + (overrunHorizontal * 2);

    //     HashSet<Vector2Int> wallPositions = GetRectangularWallPositions(gameSceneTiles, wallPositionsHeight, wallPositionsWidth);
        
    //     return wallPositions;
    // }

    /// <summary>
    /// Fills a space of specified size, then removes the positions occupied by something else.
    /// </summary>
    private static HashSet<Vector2Int> GetRectangularWallPositions(HashSet<Vector2Int> positionsToRemove, int totalPositionsHeight, int totalPositionsWidth)
    {
        // Fill the total area. 
        HashSet<Vector2Int> wallPositions = TemplateHelpers.FillRectangularCoordinates(totalPositionsHeight, totalPositionsWidth);

        // Then remove every position that is a position of something not a wall (floor, pit, etc.)
        wallPositions.RemoveWhere(positionsToRemove.Contains);
        
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
