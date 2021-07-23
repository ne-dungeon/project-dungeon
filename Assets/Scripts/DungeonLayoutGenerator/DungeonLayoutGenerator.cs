using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class DungeonLayoutGenerator : MonoBehaviour
{
    void Start()
    {
        GenerateDungeonLayout(100);
        Debug.Log(":)");
    }

    enum Direction { NORTH, SOUTH, EAST, WEST }

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
            doorPositions.Add(Direction.NORTH);
            doorPositions.Add(Direction.SOUTH);
            doorPositions.Add(Direction.EAST);
            doorPositions.Add(Direction.WEST);

            int roomIndex = Random.Range(0, availableRooms.Count);
            Room room = availableRooms[roomIndex];

            // Create temp neighbours
            Room roomNorth = new Room(roomId, room.x, room.y - 1);
            Room roomSouth = new Room(roomId, room.x, room.y + 1);
            Room roomEast = new Room(roomId, room.x + 1, room.y);
            Room roomWest = new Room(roomId, room.x - 1, room.y);
            roomId++;

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
            doorPositions.Clear();
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
