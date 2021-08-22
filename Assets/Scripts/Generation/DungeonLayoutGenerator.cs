using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class DungeonLayoutGenerator
{
    enum Direction { NORTH, SOUTH, EAST, WEST }

    /*  Returns a list of Room objects.

        Rooms contain boolean variables that indicate where their neighbour
        rooms are, if they exist (if roomNorth = true, then there is a neighbour
        room north of the room).

        Rooms contain grid coordinates that describe the placement of rooms
        in relation to each other, not the physical GameObject coordinates. */
    public RoomsList GenerateDungeonLayout(int numRooms)
    {
        RoomsList rooms = new RoomsList();
        RoomsList availableRooms = new RoomsList();
        List<Direction> doorPositions = new List<Direction>();

        int roomId = 0;

        RoomLayout originRoom = new RoomLayout(roomId, 0, 0);
        roomId++;

        rooms.Add(originRoom);
        availableRooms.Add(originRoom);

        while (rooms.Count() < numRooms)
        {    
            doorPositions.Add(Direction.NORTH);
            doorPositions.Add(Direction.SOUTH);
            doorPositions.Add(Direction.EAST);
            doorPositions.Add(Direction.WEST);

            int roomIndex = Random.Range(0, availableRooms.Count());
            RoomLayout room = availableRooms.rooms[roomIndex];

            // Create temp neighbours
            RoomLayout roomNorth = new RoomLayout(roomId, room.x, room.y + 1);
            RoomLayout roomSouth = new RoomLayout(roomId, room.x, room.y - 1);
            RoomLayout roomEast = new RoomLayout(roomId, room.x + 1, room.y);
            RoomLayout roomWest = new RoomLayout(roomId, room.x - 1, room.y);
            roomId++;

            // Remove door positions where a door is already there
            // since we don't want to overwrite it
            if (rooms.inRooms(roomNorth))
            {
                doorPositions.Remove(Direction.NORTH);
            }
            if (rooms.inRooms(roomSouth))
            {
                doorPositions.Remove(Direction.SOUTH);
            }
            if (rooms.inRooms(roomEast))
            {
                doorPositions.Remove(Direction.EAST);
            }
            if (rooms.inRooms(roomWest))
            {
                doorPositions.Remove(Direction.WEST);
            }

            // If there are no places where a new door can be placed,
            // then this room is not available for brancing.
            // So we need to remove this room from availableRooms
            if (doorPositions.Count == 0)
            {
                availableRooms.rooms.Remove(room);
            }
            else
            {
                int neighbourDirectionIndex = Random.Range(0, doorPositions.Count);
                Direction neighbourDirection = doorPositions[neighbourDirectionIndex];

                roomIndex = rooms.indexById(room.id);

                // Set the neighbour boolean values to the original room
                // and the neighbour room
                switch (neighbourDirection)
                {
                    case Direction.NORTH:
                        rooms.rooms[roomIndex].roomNorth = true;
                        roomNorth.roomSouth = true;
                        rooms.Add(roomNorth);
                        availableRooms.Add(roomNorth);
                        break;

                    case Direction.SOUTH:
                        rooms.rooms[roomIndex].roomSouth = true;
                        roomSouth.roomNorth = true;
                        rooms.Add(roomSouth);
                        availableRooms.Add(roomSouth);
                        break;

                    case Direction.EAST:
                        rooms.rooms[roomIndex].roomEast = true;
                        roomEast.roomWest = true;
                        rooms.Add(roomEast);
                        availableRooms.Add(roomEast);
                        break;

                    case Direction.WEST:
                        rooms.rooms[roomIndex].roomWest = true;
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
