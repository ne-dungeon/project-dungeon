using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class PathFinder
{
    public enum Direction { NORTH, SOUTH, EAST, WEST, NONE }

    // Returns the integer ID of the boss room
    public LayoutRoom findBossRoom(LayoutRoomsList rooms, int originId)
    {
        // Populate a list of dead end rooms with their distance from the origin room
        LayoutRoom originRoom = rooms.roomById(originId);
        List<LayoutRoom> deadEnds = assignDeadEnds(rooms, originRoom);

        // Find the dead end room farthest from the origin room
        LayoutRoom highestDeadEnd = new LayoutRoom(0, 0);

        foreach (LayoutRoom deadEnd in deadEnds)
        {
            if (deadEnd.distance > highestDeadEnd.distance)
            {
                highestDeadEnd = deadEnd;
            }
        }

        return highestDeadEnd;
    }

    private List<LayoutRoom> assignDeadEnds(LayoutRoomsList rooms, LayoutRoom currentRoom, Direction dir = Direction.NONE, int currentDistance = 0)
    {
        List<LayoutRoom> deadEndRooms = new List<LayoutRoom>();
        List<LayoutRoom> neighbours = getNeighbours(rooms, currentRoom, dir);

        if (neighbours.Count == 0)
        {
            currentRoom.distance = currentDistance;
            deadEndRooms.Add(currentRoom);
            return deadEndRooms;
        }
        else
        {
            foreach (LayoutRoom neighbour in neighbours)
            {
                Direction direction = getDir(currentRoom, neighbour);
                List<LayoutRoom> newDeadEndRooms = assignDeadEnds(rooms, neighbour, direction, currentDistance + 1);

                foreach (LayoutRoom deadEnd in newDeadEndRooms)
                {
                    deadEndRooms.Add(deadEnd);
                }
            }
        }

        return deadEndRooms;
    }

    // Gets direction of room from neighbour room
    Direction getDir(LayoutRoom room, LayoutRoom neighbourRoom)
    {
        int xDif, yDif;
        xDif = room.x - neighbourRoom.x;
        yDif = room.y - neighbourRoom.y;

        switch (yDif)
        {
        case 1:
            return Direction.NORTH;
        case -1:
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
    private List<LayoutRoom> getNeighbours(LayoutRoomsList rooms, LayoutRoom room, Direction dir)
    {
        List<LayoutRoom> neighbours = new List<LayoutRoom>();

        if (room.roomNorth && (dir != Direction.NORTH))
        {
            neighbours.Add(rooms.roomByCoords(room.x, room.y + 1));
        }
        if (room.roomSouth && (dir != Direction.SOUTH))
        {
            neighbours.Add(rooms.roomByCoords(room.x, room.y - 1));
        }
        if (room.roomEast && (dir != Direction.EAST))
        {
            neighbours.Add(rooms.roomByCoords(room.x + 1, room.y));
        }
        if (room.roomWest && (dir != Direction.WEST))
        {
            neighbours.Add(rooms.roomByCoords(room.x - 1, room.y));
        }

        return neighbours;
    }
}
