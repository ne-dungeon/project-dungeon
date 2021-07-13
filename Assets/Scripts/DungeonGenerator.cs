class DungeonGenerator
{
    enum Direction { NORTH, SOUTH, EAST, WEST }

    struct Room
    {
        int x, y;
    }

    struct Door
    {
        Room room;
        Direction wallSide;
    }

    struct DungeonLayout
    {
        List<Room> rooms;
        List<Door> doors;
    }

    int numRooms;

    // Returns a structure which stores a list of rooms and doors.
    // Rooms contain grid coordinates that describe the placement of rooms
    // in relation to each other, not the physical GameObject coordinates.
    DungeonLayout GenerateDungeon()
    {
        Random random = new Random();

        List<Room> rooms = new List<Room>();
        List<Room> availableRooms = new List<Room>();
        List<Door> doors = new List<Door>();
        List<Direction> doorPositions = new List<Direction>();

        Room originRoom;
        originRoom.x = 0;
        originRoom.y = 0;

        rooms.Add(originRoom);
        availableRooms.Add(originRoom);

        doorPositions.Add(NORTH);
        doorPositions.Add(SOUTH);
        doorPositions.Add(EAST);
        doorPositions.Add(WEST);

        while (rooms.Count < numRooms)
        {
            int roomIndex = random.next(0, availableRooms.Count);
            Room room = availableRooms[roomIndex];

            Room roomNorth = room;
            Room roomSouth = room;
            Room roomEast = room;
            Room roomWest = room;

            roomNorth.y -= 1;
            roomSouth.y += 1;
            roomEast.x += 1;
            roomWest.x -= 1;

            if inRooms(roomNorth, rooms)
            {
                doorPositions.Remove(NORTH);
            }
            if inRooms(roomSouth, rooms)
            {
                doorPositions.Remove(SOUTH);
            }
            if inRooms(roomEast, rooms)
            {
                doorPositions.Remove(EAST);
            }
            if inRooms(roomWest, rooms)
            {
                doorPositions.Remove(WEST);
            }

            if (doorPositions.Count == 0)
            {
                availableRooms.Remove(room);
            }
            else
            {
                int neighbourDirectionIndex = random.next(0, doorPositions.Count);
                Direction neighbourDirection = doorPositions[neighbourDirectionIndex];
                Room neighbourRoom;

                if (neighbourDirection == NORTH)
                {
                    neighbourRoom = roomNorth;
                }
                else if (neighbourDirection == SOUTH)
                {
                    neighbourRoom = roomSouth;
                }
                else if (neighbourDirection == EAST)
                {
                    neighbourRoom = roomEast;
                }
                else if (neighbourDirection == WEST)
                {
                    neighbourRoom == roomWest;
                }

                Door door;
                door.room = room;
                door.wallSide = neighbourDirection;

                doors.Add(door);
                rooms.Add(neighbourRoom);
                availableRooms.Add(neighbourRoom);
            }
        }

        DungeonLayout dl;
        dl.rooms = rooms;
        dl.doors = doors;

        return dl;
    }

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
}