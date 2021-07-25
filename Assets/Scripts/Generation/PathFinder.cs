using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class PathFinder
{
    public enum Direction { NONE, NORTH, SOUTH, EAST, WEST }

    // Returns the integer ID of the boss room
    public Room findBossRoom(RoomsList rooms, int originId)
    {
        // Populate a list of dead end rooms with their distance from the origin room
        Room originRoom = rooms.rooms[rooms.indexById(originId)];
        List<Room> deadEnds = assignDeadEnds(rooms, originRoom);

        // Find the dead end room farthest from the origin room
        int highestID = 0;
        int highestDistance = 0;

        foreach (Room deadEnd in deadEnds)
        {
            if (deadEnd.distance > highestDistance)
            {
                highestDistance = deadEnd.distance;
                highestID = deadEnd.id;
            }
        }

        return rooms.rooms[rooms.indexById(highestID)];
    }

    private List<Room> assignDeadEnds(RoomsList rooms, Room currentRoom, Direction dir = Direction.NONE, int currentDistance = 0)
    {
        List<Room> deadEndRooms = new List<Room>();
        List<Room> neighbours = getNeighbours(rooms, currentRoom, dir);

        if (neighbours.Count == 0)
        {
            currentRoom.distance = currentDistance;
            deadEndRooms.Add(currentRoom);
            return deadEndRooms;
        }
        else
        {
            foreach (Room neighbour in neighbours)
            {
                Direction direction = getDir(currentRoom, neighbour);
                List<Room> newDeadEndRooms = assignDeadEnds(rooms, neighbour, direction, currentDistance + 1);

                foreach (Room deadEnd in newDeadEndRooms)
                {
                    deadEndRooms.Add(deadEnd);
                }
            }
        }

        return deadEndRooms;
    }

    // Gets direction of room from neighbour room
    Direction getDir(Room room, Room neighbourRoom)
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
    private List<Room> getNeighbours(RoomsList rooms, Room room, Direction dir)
    {
        List<Room> neighbours = new List<Room>();

        if (room.roomNorth && (dir != Direction.NORTH))
        {
            int id = rooms.idByCoords(room.x, room.y + 1);
            neighbours.Add(rooms.rooms[rooms.indexById(id)]);
        }
        if (room.roomSouth && (dir != Direction.SOUTH))
        {
            int id = rooms.idByCoords(room.x, room.y - 1);
            neighbours.Add(rooms.rooms[rooms.indexById(id)]);
        }
        if (room.roomEast && (dir != Direction.EAST))
        {
            int id = rooms.idByCoords(room.x + 1, room.y);
            neighbours.Add(rooms.rooms[rooms.indexById(id)]);
        }
        if (room.roomWest && (dir != Direction.WEST))
        {
            int id = rooms.idByCoords(room.x - 1, room.y);
            neighbours.Add(rooms.rooms[rooms.indexById(id)]);
        }

        return neighbours;
    }
}
