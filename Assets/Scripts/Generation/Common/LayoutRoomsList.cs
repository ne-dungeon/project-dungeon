using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LayoutRoomsList
{
    public List<LayoutRoom> rooms;

    public LayoutRoomsList()
    {
        rooms = new List<LayoutRoom>();
    }

    public void Add(LayoutRoom room)
    {
        rooms.Add(room);
    }

    public int Count()
    {
        return rooms.Count;
    }

    // Checks if a room (defined by its coordinates) is in the rooms list
    public bool inRooms(LayoutRoom room)
    {
        foreach (LayoutRoom r in rooms)
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

    public LayoutRoom roomById(int id)
    {
        foreach (LayoutRoom room in rooms)
        {
            if (room.id == id)
            {
                return room;
            }
        }
        return new LayoutRoom(0, 0);
    }


    // Get the ID of a from from its coordinates
    public int idByCoords(int x, int y)
    {
        foreach (LayoutRoom room in rooms)
        {
            if (x == room.x && y == room.y)
            {
                return room.id;
            }
        }
        return -1;
    }

    public LayoutRoom roomByCoords(int x, int y)
    {
        foreach (LayoutRoom room in rooms)
        {
            if (x == room.x && y == room.y)
            {
                return room;
            }
        }

        // Room not found error
        return new LayoutRoom(-1, -1);
    }
}