using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LayoutRoom
{
    public int id;
    public int x, y;
    public bool roomNorth, roomSouth, roomEast, roomWest;

    public int distance;

    public LayoutRoom(int _x, int _y)
    {
        x = _x;
        y = _y;

        roomNorth = false;
        roomWest = false;
        roomSouth = false;
        roomEast = false;
    }

    public LayoutRoom(int _id, int _x, int _y)
    {
        id = _id;

        x = _x;
        y = _y;

        roomNorth = false;
        roomWest = false;
        roomSouth = false;
        roomEast = false;
    }
}
