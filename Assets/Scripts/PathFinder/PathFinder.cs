
class PathFinder
{
    enum Direction { NONE, NORTH, SOUTH, EAST, WEST }

    // Returns the integer ID of the boss room
    public int findBossRoom(List<Room> rooms, int originId, Direction dir = Direction.NONE)
    {
        /*
        // Add distance values
        for (int i = 0; i < rooms.Count; i++)
        {
            // Every room apart from the origin room has an "infinite" initial
            // distance from the origin room. No path will ever be greater than
            // the room count + 1.
            rooms[i].distance = rooms.Count + 1;
        }

        // The origin room has a distance of 0
        rooms[indexById(rooms, originId)].distance = 0;

        List<DungeonLayout.Room> unvisited = new List<Room>();
        int currentNodeId = originId;
        */

        // Count length of all possible paths with recursion

        Room currentRoom = rooms[indexById(originId)];

        getNeighbours()
    }

    // Dir is the door the search entered the room through
    private List<Room> getNeighbours(Room room, Direction dir)
    {
        List<Direction> nextDirs = new List<Direction>();

        if (room.roomNorth)
        {
            nextDirs.Add(Direction.NORTH);
        }
        else if (room.roomSouth)
        {
            nextDirs.Add(Direction.SOUTH);
        }
        else if (room.roomEast)
        {
            nextDirs.Add(Direction.EAST);
        }
        else if (room.roomWest)
        {
            nextDirs.Add(Direction.WEST);
        }

        nextDirs.Remove(dir);

        // now nextDirs is a list of doors to enter next

        
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
