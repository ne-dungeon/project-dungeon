
class PathFinder
{
    // Returns the integer ID of the boss room
    int findBossRoom(List<DungeonLayout.Room> rooms, int originId)
    {
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

        
    }

    private getUnvisitedNeighbours()
    {

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
