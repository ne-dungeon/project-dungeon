
class PathFinder
{
    enum Direction { NONE, NORTH, SOUTH, EAST, WEST }

    // Returns the integer ID of the boss room
    public int findBossRoom(List<Room> rooms, int originId, Direction dir = Direction.NONE, int currentDistance = 0)
    {
        // Count length of all possible paths with recursion

        int index = indexById(originId);
        rooms[index].distance = currentDistance;
        Room currentRoom = rooms[index];

        List<int> neighbourIds = getNeighbours(rooms, currentRoom, dir);
        // now neighbourDirs is a list of doors to enter next

        // if there are 0 directions left, you have reached a dead end
        if (neighbourIds.Count == 0)
        {
            return 0;
        }
        else
        {
            for (int id in neighbourIds)
            {
                indexById(rooms, id)
            }
        }

        // otherwise iterate through them 
        //
        
    }

    // Gets direction of room from neighbour room
    Direction dir getDir(Room room, Room neighbourRoom)
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

    // Get the ID of a from from its coordinates
    private int idByCoords(List<Room> rooms, int x, int y)
    {
        foreach (Room room in rooms)
        {
            if (x == room.x and y == room.y)
            {
                return room.id;
            }
        }
    }
}
