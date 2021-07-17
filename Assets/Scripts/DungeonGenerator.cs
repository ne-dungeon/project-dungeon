using System.Collections;
using System.Collections.Generic;

using UnityEngine;


class DungeonGenerator : MonoBehaviour
{
    enum Direction { NORTH, SOUTH, EAST, WEST }

    class Room
    {
        public int id;
        public int x, y;
        public bool roomNorth, roomSouth, roomEast, roomWest;

        public Room(int _id, int _x, int _y)
        {
            id = _id;

            x = _x;
            y = _y;

            roomNorth = false;
            roomSouth = false;
            roomEast = false;
            roomWest = false;
        }
    }

    /*  Returns a list of Room objects.

        Rooms contain boolean variables that indicate where their neighbour
        rooms are, if they exist (if roomNorth = true, then there is a neighbour
        room north of the room).

        Rooms contain grid coordinates that describe the placement of rooms
        in relation to each other, not the physical GameObject coordinates. */
    List<Room> GenerateDungeonLayout(int numRooms)
    {
        List<Room> rooms = new List<Room>();
        List<Room> availableRooms = new List<Room>();
        List<Direction> doorPositions = new List<Direction>();

        int roomId = 0;

        Room originRoom = new Room(roomId, 0, 0);
        roomId++;

        rooms.Add(originRoom);
        availableRooms.Add(originRoom);

        doorPositions.Add(Direction.NORTH);
        doorPositions.Add(Direction.SOUTH);
        doorPositions.Add(Direction.EAST);
        doorPositions.Add(Direction.WEST);

        while (rooms.Count < numRooms)
        {
            int roomIndex = Random.Range(0, availableRooms.Count);
            Room room = availableRooms[roomIndex];

            // Create a replica of the room with no neighbours
            Room tempRoom = new Room(roomId, room.x, room.y);
            roomId++;

            // Use that replica to make neighbour rooms for all sides of
            // the current room
            Room roomNorth = tempRoom;
            Room roomSouth = tempRoom;
            Room roomEast = tempRoom;
            Room roomWest = tempRoom;

            // Shift these rooms to their correct coordinates
            roomNorth.y -= 1;
            roomSouth.y += 1;
            roomEast.x += 1;
            roomWest.x -= 1;

            // Remove door positions where a door is already there
            // since we don't want to overwrite it
            if (inRooms(roomNorth, rooms))
            {
                doorPositions.Remove(Direction.NORTH);
            }
            if (inRooms(roomSouth, rooms))
            {
                doorPositions.Remove(Direction.SOUTH);
            }
            if (inRooms(roomEast, rooms))
            {
                doorPositions.Remove(Direction.EAST);
            }
            if (inRooms(roomWest, rooms))
            {
                doorPositions.Remove(Direction.WEST);
            }

            // If there are no places where a new door can be placed,
            // then this room is not available for brancing.
            // So we need to remove this room from availableRooms
            if (doorPositions.Count == 0)
            {
                availableRooms.Remove(room);
            }
            else
            {
                int neighbourDirectionIndex = Random.Range(0, doorPositions.Count);
                Direction neighbourDirection = doorPositions[neighbourDirectionIndex];

                // Set the neighbour boolean values to the original room
                // and the neighbour room
                switch (neighbourDirection)
                {
                    case Direction.NORTH:
                        rooms[indexById(rooms, room.id)].roomNorth = true;
                        roomNorth.roomSouth = true;
                        rooms.Add(roomNorth);
                        availableRooms.Add(roomNorth);
                        break;

                    case Direction.SOUTH:
                        rooms[indexById(rooms, room.id)].roomSouth = true;
                        roomSouth.roomNorth = true;
                        rooms.Add(roomSouth);
                        availableRooms.Add(roomSouth);
                        break;

                    case Direction.EAST:
                        rooms[indexById(rooms, room.id)].roomEast = true;
                        roomEast.roomWest = true;
                        rooms.Add(roomEast);
                        availableRooms.Add(roomEast);
                        break;

                    case Direction.WEST:
                        rooms[indexById(rooms, room.id)].roomWest = true;
                        roomWest.roomEast = true;
                        rooms.Add(roomWest);
                        availableRooms.Add(roomWest);
                        break;
                }
            }
        }

        return rooms;
    }

    // Checks if a room (defined by its coordinates) is in the rooms list
    private bool inRooms(Room room, List<Room> rooms)
    {
        foreach (Room r in rooms)
        {
            if (r.x == room.x && r.y == room.y)
            {
                return true;
            }
        }
        return false;
    }

    // Finds the index of a Room object in the rooms list
    private int indexById(List<Room> rooms, int id)
    {
        for (int i = 0; i < rooms.Count; i++)
        {
            if (rooms[i].id == id)
            {
                return i;
            }
        }

        // The room was not found (which should never happen)
        return -1;
    }
}