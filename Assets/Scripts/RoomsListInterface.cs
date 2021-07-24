using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class RoomsListInterface
{
    // Checks if a room (defined by its coordinates) is in the rooms list
    public static bool inRooms(Room room, List<Room> rooms)
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
    public static int indexById(List<Room> rooms, int id)
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

    public static Room roomById(List<Room> rooms, int id)
    {
        foreach (Room room in rooms)
        {
            if (room.id == id)
            {
                return room;
            }
        }
        return new Room(0, 0);
    }
}