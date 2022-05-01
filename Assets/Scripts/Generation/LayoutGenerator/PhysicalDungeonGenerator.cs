using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalDungeonGenerator : MonoBehaviour
{
    private LayoutRoom startingRoom;
    private LayoutRoom bossRoom;

    // Temporary Variables (FOR TESTING)
    [SerializeField]
    private int totalRooms;

    [SerializeField]
    private uint seed = 0x12345678;

    AbstractLayoutGenerator layoutGenerator;

    private List<GameObject> activePrefabs = new List<GameObject>();

    public void RunDungeonGen()
    {
      /*
        RandomHash.seed = seed;

        layoutGenerator = new BasicLayoutGenerator();
        LayoutRoomsList rooms = layoutGenerator.GenerateDungeonLayout(totalRooms);

        //startingRoom = rooms.rooms[(int)(RandomHash.Hash(1) % rooms.rooms.Count)];

        foreach (LayoutRoom room in rooms.rooms)
        {
            GeneratePhysicalRoom(room);
        }
        */
    }

    private void GeneratePhysicalRoom(LayoutRoom room)
    {
      /*
        float dif = 1.25f;
        RoomPrefab rpfb_script = rpfb.GetComponent<RoomPrefab>();
        GameObject newRoom = Instantiate(rpfb, new Vector3(room.x * dif, room.y * dif, 0), transform.rotation);
        activePrefabs.Add(newRoom);
        */
    }

    internal void ClearPhysicalRooms()
    {
        foreach (var prefab in activePrefabs)
        {
            DestroyImmediate(prefab);
        }
    }
}