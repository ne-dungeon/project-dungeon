using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Room
{
    public int id;
    public int x, y;
    public bool roomNorth, roomSouth, roomEast, roomWest;

    public int distance;

    public Room(int _id, int _x, int _y)
    {
        id = _id;

        x = _x;
        y = _y;

        roomNorth = false;
        roomSouth = false;
        roomEast = false;
        roomWest = false;
    }
}
