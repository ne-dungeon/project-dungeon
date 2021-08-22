using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoomsList
{
    public List<RoomLayout> rooms;

    public RoomsList()
    {
        rooms = new List<RoomLayout>();
    }

    public void Add(RoomLayout room)
    {
        rooms.Add(room);
    }

    public int Count()
    {
        return rooms.Count;
    }

    // Checks if a room (defined by its coordinates) is in the rooms list
    public bool inRooms(RoomLayout room)
    {
        foreach (RoomLayout r in rooms)
        {
            if (r.x == room.x && r.y == room.y)
            {
                return true;
            }
        }
        return false;
    }

    // Finds the index of a Room object in the rooms list
    public int indexById(int id)
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

    public RoomLayout roomById(int id)
    {
        foreach (RoomLayout room in rooms)
        {
            if (room.id == id)
            {
                return room;
            }
        }
        return new RoomLayout(0, 0);
    }


    // Get the ID of a from from its coordinates
    public int idByCoords(int x, int y)
    {
        foreach (RoomLayout room in rooms)
        {
            if (x == room.x && y == room.y)
            {
                return room.id;
            }
        }
        return -1;
    }

    public RoomLayout roomByCoords(int x, int y)
    {
        foreach (RoomLayout room in rooms)
        {
            if (x == room.x && y == room.y)
            {
                return room;
            }
        }

        // Room not found error
        return new RoomLayout(-1, -1);
    }
}