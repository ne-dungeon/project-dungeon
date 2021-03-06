using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutGenerator : MonoBehaviour
{

    private LayoutRoomsList rooms;
    private LayoutRoom startingRoom;
    private LayoutRoom bossRoom;

    // Temporary Variables (FOR TESTING)
    [SerializeField]
    private int totalRooms;

    [SerializeField]
    private uint seed = 0x12345678;

    [SerializeField]
    private int dungeonNumber = 1;

    [SerializeField]
    private int level = 1;

    [SerializeField]
    private List<GameObject> roomPrefabs = new List<GameObject>();

    AbstractLayoutGenerator layoutGenerator;

    // The active room prefabs in the scene.
    private List<GameObject> activePrefabs = new List<GameObject>();

    public void CreateLayout()
    {
        // First clear the existing layout.
        ClearPrefabLayout();

        RandomHash.seed = seed;

        // Then set the generator and create the rooms.
        layoutGenerator = new BasicLayoutGenerator();
        rooms = layoutGenerator.GenerateDungeonLayout(dungeonNumber, level, totalRooms);

        // Setting a random origin room

        // Passing a constant into the hash function will make the
        // randomness depend on the game seed
        var hash = RandomHash.Hash(1, level);
        startingRoom = rooms.rooms[(int)(hash % rooms.rooms.Count)];

        // FINDING THE BOSS ROOM //
        PathFinder pf = new PathFinder(rooms, startingRoom);

        bossRoom = pf.findBossRoom();
    }

    public void CreatePrefabLayout()
    {
        foreach (LayoutRoom room in rooms.rooms)
        {
            GenerateRoomPrefab(room);
        }
    }

    public void ClearPrefabLayout()
    {
        if (activePrefabs.Count > 0)
        {
            foreach (var prefab in activePrefabs)
            {
                DestroyImmediate(prefab);
            }
        }
    }

    void GenerateRoomPrefab(LayoutRoom room)
    {
        float dif = 1.25f;
        foreach (var rpfb in roomPrefabs)
        {
            RoomPrefab rpfb_script = rpfb.GetComponent<RoomPrefab>();

            if (rpfb_script.roomNorth == room.roomNorth
            && rpfb_script.roomEast == room.roomEast
            && rpfb_script.roomSouth == room.roomSouth
            && rpfb_script.roomWest == room.roomWest)
            {
                GameObject newRoom = Instantiate(rpfb, new Vector3(room.x * dif, room.y * dif, 0),
                    transform.rotation);

                // Add these to the list so they are easy to clear later.
                activePrefabs.Add(newRoom);

                if (room == startingRoom)
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
