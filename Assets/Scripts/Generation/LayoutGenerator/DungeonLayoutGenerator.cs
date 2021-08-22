using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class DungeonLayoutGenerator
{
    /*  Returns a list of Room objects.

        Rooms contain boolean variables that indicate where their neighbour
        rooms are, if they exist (if roomNorth = true, then there is a neighbour
        room north of the room).

        Rooms contain grid coordinates that describe the placement of rooms
        in relation to each other, not the physical GameObject coordinates. */
    public LayoutRoomsList GenerateDungeonLayout(int numRooms)
    {
        LayoutRoomsList rooms = new LayoutRoomsList();
        LayoutRoomsList availableRooms = new LayoutRoomsList();
        List<DoorDirection> doorPositions = new List<DoorDirection>();

        int roomId = 0;

        LayoutRoom originRoom = new LayoutRoom(roomId, 0, 0);
        roomId++;

        rooms.Add(originRoom);
        availableRooms.Add(originRoom);

        while (rooms.Count() < numRooms)
        {
            doorPositions.Add(DoorDirection.NORTH);
            doorPositions.Add(DoorDirection.SOUTH);
            doorPositions.Add(DoorDirection.EAST);
            doorPositions.Add(DoorDirection.WEST);

            int roomIndex = Random.Range(0, availableRooms.Count());
            LayoutRoom room = availableRooms.rooms[roomIndex];

            // Create temp neighbours
            LayoutRoom roomNorth = new LayoutRoom(roomId, room.x, room.y + 1);
            LayoutRoom roomSouth = new LayoutRoom(roomId, room.x, room.y - 1);
            LayoutRoom roomEast = new LayoutRoom(roomId, room.x + 1, room.y);
            LayoutRoom roomWest = new LayoutRoom(roomId, room.x - 1, room.y);
            roomId++;

            // Remove door positions where a door is already there
            // since we don't want to overwrite it
            if (rooms.inRooms(roomNorth))
            {
                doorPositions.Remove(DoorDirection.NORTH);
            }
            if (rooms.inRooms(roomSouth))
            {
                doorPositions.Remove(DoorDirection.SOUTH);
            }
            if (rooms.inRooms(roomEast))
            {
                doorPositions.Remove(DoorDirection.EAST);
            }
            if (rooms.inRooms(roomWest))
            {
                doorPositions.Remove(DoorDirection.WEST);
            }

            // If there are no places where a new door can be placed,
            // then this room is not available for branching.
            // So we need to remove this room from availableRooms
            if (doorPositions.Count == 0)
            {
                availableRooms.rooms.Remove(room);
            }
            else
            {
                int neighbourDirectionIndex = Random.Range(0, doorPositions.Count);
                DoorDirection neighbourDirection = doorPositions[neighbourDirectionIndex];

                roomIndex = rooms.indexById(room.id);

                // Set the neighbour boolean values to the original room
                // and the neighbour room
                switch (neighbourDirection)
                {
                    case DoorDirection.NORTH:
                        rooms.rooms[roomIndex].roomNorth = true;
                        roomNorth.roomSouth = true;
                        rooms.Add(roomNorth);
                        availableRooms.Add(roomNorth);
                        break;

                    case DoorDirection.SOUTH:
                        rooms.rooms[roomIndex].roomSouth = true;
                        roomSouth.roomNorth = true;
                        rooms.Add(roomSouth);
                        availableRooms.Add(roomSouth);
                        break;

                    case DoorDirection.EAST:
                        rooms.rooms[roomIndex].roomEast = true;
                        roomEast.roomWest = true;
                        rooms.Add(roomEast);
                        availableRooms.Add(roomEast);
                        break;

                    case DoorDirection.WEST:
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
