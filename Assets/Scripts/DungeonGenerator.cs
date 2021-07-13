using System.Collections;
using System.Collections.Generic;

using UnityEngine;


class DungeonGenerator : MonoBehaviour
{
    enum Direction { NORTH, SOUTH, EAST, WEST }

    struct Room
    {
        public int x, y;
    }

    struct Door
    {
        public Room room;
        public Direction wallSide;
    }

    struct DungeonLayout
    {
        public List<Room> rooms;
        public List<Door> doors;
    }

    GameObject roomPrefab;

    void Start()
    {
        DungeonLayout dl = GenerateDungeonLayout(9);
    }

    // Returns a structure which stores a list of rooms and doors.
    // Rooms contain grid coordinates that describe the placement of rooms
    // in relation to each other, not the physical GameObject coordinates.
    DungeonLayout GenerateDungeonLayout(int numRooms)
    {
        List<Room> rooms = new List<Room>();
        List<Room> availableRooms = new List<Room>();
        List<Door> doors = new List<Door>();
        List<Direction> doorPositions = new List<Direction>();

        Room originRoom;
        originRoom.x = 0;
        originRoom.y = 0;

        rooms.Add(originRoom);
        availableRooms.Add(originRoom);

        doorPositions.Add(Direction.NORTH);
        doorPositions.Add(Direction.SOUTH);
        doorPositions.Add(Direction.EAST);
        doorPositions.Add(Direction.WEST);

        while (rooms.Count < numRooms)
        {
            int roomIndex = Random.Range(0, availableRooms.Count);
            Room room = availableRooms[roomIndex];

            Room roomNorth = room;
            Room roomSouth = room;
            Room roomEast = room;
            Room roomWest = room;

            roomNorth.y -= 1;
            roomSouth.y += 1;
            roomEast.x += 1;
            roomWest.x -= 1;

            if (inRooms(roomNorth, rooms))
            {
                doorPositions.Remove(Direction.NORTH);
            }
            if (inRooms(roomSouth, rooms))
            {
                doorPositions.Remove(Direction.SOUTH);
            }
            if (inRooms(roomEast, rooms))
            {
                doorPositions.Remove(Direction.EAST);
            }
            if (inRooms(roomWest, rooms))
            {
                doorPositions.Remove(Direction.WEST);
            }

            if (doorPositions.Count == 0)
            {
                availableRooms.Remove(room);
            }
            else
            {
                int neighbourDirectionIndex = Random.Range(0, doorPositions.Count);
                Direction neighbourDirection = doorPositions[neighbourDirectionIndex];
                Room neighbourRoom;

                if (neighbourDirection == Direction.NORTH)
                {
                    neighbourRoom = roomNorth;
                }
                else if (neighbourDirection == Direction.SOUTH)
                {
                    neighbourRoom = roomSouth;
                }
                else if (neighbourDirection == Direction.EAST)
                {
                    neighbourRoom = roomEast;
                }
                else if (neighbourDirection == Direction.WEST)
                {
                    neighbourRoom = roomWest;
                }
                else
                {
                    // Else there is an error
                    neighbourRoom = room;
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

    // Place the rooms and doors in the dungeon layout in the physical game world
    void PlaceDungeon(DungeonLayout dl)
    {
        float roomWidth = roomPrefab.GetComponent<BoxCollider2D>().size.x;
        float roomHeight = roomPrefab.GetComponent<BoxCollider2D>().size.y;
        foreach (Room room in dl.rooms)
        {
            roomPrefab.transform = new Vector3(room.x * roomWidth, room.y * roomHeight, 0);
            GameObject.Instantiate(roomPrefab);
        }
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