using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class PathFinder
{
    public enum Direction { NONE, NORTH, SOUTH, EAST, WEST }

    // Returns the integer ID of the boss room
    public Room findBossRoom(List<Room> rooms, int originId)
    {
        // Populate a list of dead end rooms with their distance from the origin room

        Room originRoom = rooms[RoomsListInterface.indexById(rooms, originId)];

        List<Room> deadEnds = assignDeadEnds(rooms, originRoom);

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

        return rooms[RoomListInterface.indexById(rooms, highestID)];

    }

    private List<Room> assignDeadEnds(List<Room> rooms, Room currentRoom, Direction dir = Direction.NONE, int currentDistance = 0)
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
    private List<Room> getNeighbours(List<Room> rooms, Room room, Direction dir)
    {
        List<Room> neighbours = new List<Room>();

        if (room.roomNorth && (dir != Direction.NORTH))
        {
            int id = idByCoords(rooms, room.x, room.y + 1);
            neighbours.Add(rooms[RoomListInterface.indexById(id)]);
        }
        if (room.roomSouth && (dir != Direction.SOUTH))
        {
            int id = idByCoords(rooms, room.x, room.y - 1);
            neighbours.Add(rooms[RoomListInterface.indexById(id)]);
        }
        if (room.roomEast && (dir != Direction.EAST))
        {
            int id = idByCoords(rooms, room.x + 1, room.y);
            neighbours.Add(rooms[RoomListInterface.indexById(id)]);
        }
        if (room.roomWest && (dir != Direction.WEST))
        {
            int id = idByCoords(rooms, room.x - 1, room.y);
            neighbours.Add(rooms[RoomListInterface.indexById(id)]);
        }

        return neighbours;
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
