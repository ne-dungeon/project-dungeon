using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class PathFinder
{
    public enum Direction { NONE, NORTH, SOUTH, EAST, WEST }

    // Returns the integer ID of the boss room
    public int findBossRoom(List<Room> rooms, int originId, Direction dir = Direction.NONE, int currentDistance = 0)
    {
        List<Room> traversedRooms = assignDistances(rooms, originId);

        int highestDistanceId = 0;
        int highestDistance = 0;

        foreach (Room room in traversedRooms)
        {
            if (room.distance > highestDistance)
            {
                highestDistance = room.distance;
                highestDistanceId = room.id;
            }
        }

        return highestDistanceId;
    }

    private List<Room> assignDistances(List<Room> rooms, int currentId, Direction dir = Direction.NONE, int currentDistance = 0)
    {
        int index = indexById(rooms, currentId);
        rooms[index].distance = currentDistance;
        Room currentRoom = rooms[index];

        List<int> neighbourIds = getNeighbours(rooms, currentRoom, dir);

        if (neighbourIds.Count == 0)
        {
            return rooms;
        }

        foreach (int id in neighbourIds)
        {
            Room neighbour = rooms[indexById(rooms, id)];
            Direction neighbourDir = getDir(currentRoom, neighbour);
            assignDistances(rooms, id, neighbourDir, currentDistance + 1);
        }

        return rooms;
    }

    // Gets direction of room from neighbour room
    Direction getDir(Room room, Room neighbourRoom)
    {
        int xDif, yDif;
        xDif = room.x - neighbourRoom.x;
        yDif = room.y - neighbourRoom.y;

        switch (yDif)
        {
        case -1:
            return Direction.NORTH;
        case 1:
            return Direction.SOUTH;
        }

        switch (xDif)
        {
        case 1:
            return Direction.EAST;
        case -1:
            return Direction.WEST;
        }

        return Direction.NONE;
    }

    // Dir is the door the search entered the room through
    private List<int> getNeighbours(List<Room> rooms, Room room, Direction dir)
    {
        List<int> neighbourIds = new List<int>();

        if (room.roomNorth && dir != Direction.NORTH)
        {
            neighbourIds.Add(idByCoords(rooms, room.x, room.y - 1));
        }
        else if (room.roomSouth && dir != Direction.SOUTH)
        {
            neighbourIds.Add(idByCoords(rooms, room.x, room.y + 1));
        }
        else if (room.roomEast && dir != Direction.EAST)
        {
            neighbourIds.Add(idByCoords(rooms, room.x + 1, room.y));
        }
        else if (room.roomWest && dir != Direction.WEST)
        {
            neighbourIds.Add(idByCoords(rooms, room.x - 1, room.y));
        }

        return neighbourIds;
    }

    // Get the ID of a from from its coordinates
    private int idByCoords(List<Room> rooms, int x, int y)
    {
        foreach (Room room in rooms)
        {
            if (x == room.x && y == room.y)
            {
                return room.id;
            }
        }
        return -1;
    }
}
