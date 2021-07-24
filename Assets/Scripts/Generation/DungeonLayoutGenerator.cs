using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class DungeonLayoutGenerator : MonoBehaviour
{
    enum Direction { NORTH, SOUTH, EAST, WEST }

    /*  Returns a list of Room objects.

        Rooms contain boolean variables that indicate where their neighbour
        rooms are, if they exist (if roomNorth = true, then there is a neighbour
        room north of the room).

        Rooms contain grid coordinates that describe the placement of rooms
        in relation to each other, not the physical GameObject coordinates. */
    public List<Room> GenerateDungeonLayout(int numRooms)
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
            Room roomNorth = new Room(roomId, room.x, room.y + 1);
            Room roomSouth = new Room(roomId, room.x, room.y - 1);
            Room roomEast = new Room(roomId, room.x + 1, room.y);
            Room roomWest = new Room(roomId, room.x - 1, room.y);
            roomId++;

            // Remove door positions where a door is already there
            // since we don't want to overwrite it
            if (RoomsListInterface.inRooms(roomNorth, rooms))
            {
                doorPositions.Remove(Direction.NORTH);
            }
            if (RoomsListInterface.inRooms(roomSouth, rooms))
            {
                doorPositions.Remove(Direction.SOUTH);
            }
            if (RoomsListInterface.inRooms(roomEast, rooms))
            {
                doorPositions.Remove(Direction.EAST);
            }
            if (RoomsListInterface.inRooms(roomWest, rooms))
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
                        rooms[RoomsListInterface.indexById(rooms, room.id)].roomNorth = true;
                        roomNorth.roomSouth = true;
                        rooms.Add(roomNorth);
                        availableRooms.Add(roomNorth);
                        break;

                    case Direction.SOUTH:
                        rooms[RoomsListInterface.indexById(rooms, room.id)].roomSouth = true;
                        roomSouth.roomNorth = true;
                        rooms.Add(roomSouth);
                        availableRooms.Add(roomSouth);
                        break;

                    case Direction.EAST:
                        rooms[RoomsListInterface.indexById(rooms, room.id)].roomEast = true;
                        roomEast.roomWest = true;
                        rooms.Add(roomEast);
                        availableRooms.Add(roomEast);
                        break;

                    case Direction.WEST:
                        rooms[RoomsListInterface.indexById(rooms, room.id)].roomWest = true;
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
}
