using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DoorGenerator
{
    // How many tiles deep the door is graphically.
    private static int doorDepth = WallGenerator.WALLWIDTH;

    // Gets the positions of walls of specified width surrounding the room.
    public static HashSet<Vector2Int> GetDoors(HashSet<DoorDetails> doors, int roomHeight, int roomWidth)
    {
        // Example: a room height 8 has floor tiles from -4 through 3 y. Therefore,
        // the walls will begin at -5 (south wall) and 4 (north wall), respectively.
        int northWallY = (roomHeight / 2);
        int southWallY = -(roomHeight / 2) - 1;
        int eastWallX = (roomWidth / 2);
        int westWallX = -(roomWidth / 2) - 1;

        HashSet<Vector2Int> doorCoords = new HashSet<Vector2Int>();

        foreach (var door in doors)
        {
            switch (door.direction)
            {
                case DoorDirection.NORTH:
                    AddNorthDoor(doorCoords, northWallY, door.position);
                    break;
                case DoorDirection.SOUTH:
                    AddSouthDoor(doorCoords, southWallY, door.position);
                    break;
                case DoorDirection.EAST:
                    AddEastDoor(doorCoords, eastWallX, door.position);
                    break;
                case DoorDirection.WEST:
                    AddWestDoor(doorCoords, westWallX, door.position);
                    break;
                default:
                    break;
            }

        }

        return doorCoords;
    }

    private static void AddNorthDoor(HashSet<Vector2Int> doorCoords, int northWallY, int doorPosition)
    {
        for (int i = 0; i < doorDepth; i++)
        {
            doorCoords.Add(new Vector2Int(doorPosition, (northWallY + i)));
            doorCoords.Add(new Vector2Int((doorPosition - 1), (northWallY + i)));
        }
    }

    private static void AddSouthDoor(HashSet<Vector2Int> doorCoords, int southWallY, int doorPosition)
    {
        for (int i = 0; i < doorDepth; i++)
        {
            doorCoords.Add(new Vector2Int(doorPosition, (southWallY - i)));
            doorCoords.Add(new Vector2Int((doorPosition - 1), (southWallY - i)));
        }
    }

    private static void AddEastDoor(HashSet<Vector2Int> doorCoords, int eastWallX, int doorPosition)
    {
        for (int i = 0; i < doorDepth; i++)
        {
            doorCoords.Add(new Vector2Int((eastWallX + i), (doorPosition)));
            doorCoords.Add(new Vector2Int((eastWallX + i), (doorPosition - 1)));
        }
    }

    private static void AddWestDoor(HashSet<Vector2Int> doorCoords, int westWallX, int doorPosition)
    {
        for (int i = 0; i < doorDepth; i++)
        {
            doorCoords.Add(new Vector2Int((westWallX - i), doorPosition));
            doorCoords.Add(new Vector2Int((westWallX - i), (doorPosition - 1)));
        }
    }
}
