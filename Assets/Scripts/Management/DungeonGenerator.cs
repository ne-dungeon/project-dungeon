using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class DungeonGenerator : MonoBehaviour
{
    // Temporary Variables (FOR TESTING)
    [SerializeField]
    private int totalRooms;
    private Room startingRoom;
    private Room bossRoom;

    [SerializeField]
    private GameObject[] roomPrefabs;

    private void Start()
    {
        DungeonLayoutGenerator dlg = new DungeonLayoutGenerator();
        RoomsList rooms = dlg.GenerateDungeonLayout(totalRooms);

        // Setting a random origin room
        startingRoom = rooms.rooms[Random.Range(0, rooms.rooms.Count)];

        // FINDING THE BOSS ROOM //

        PathFinder pf = new PathFinder();

        Room bossRoom = pf.findBossRoom(rooms, startingRoom.id);

        foreach (Room room in rooms.rooms)
        {
            //print("Coords: " + room.x + "," + room.y);
            GenerateRoomPrefab(room);
            print("room: " + room.x + "," + room.y);
        }

        print("Boss room: " + bossRoom.x + "," + bossRoom.y);
    }

    void GenerateRoomPrefab(Room room)
    {
        float dif = 1.25f;
        foreach (var rpfb in roomPrefabs)
        {
            RoomPrefab rpfb_script = rpfb.GetComponent<RoomPrefab>();

            if(rpfb_script.roomNorth == room.roomNorth
            && rpfb_script.roomEast == room.roomEast
            && rpfb_script.roomSouth == room.roomSouth
            && rpfb_script.roomWest == room.roomWest)
            {
                GameObject newRoom = Instantiate(rpfb, new Vector3(room.x * dif, room.y * dif, 0),
                    transform.rotation);

                if(room == startingRoom)
                {
                    newRoom.transform.Find("base").GetComponent<SpriteRenderer>().color = Color.blue;
                }
                else if (room == bossRoom)
                {
                    newRoom.transform.Find("base").GetComponent<SpriteRenderer>().color = Color.red;
                }
            }
        }
    }
}