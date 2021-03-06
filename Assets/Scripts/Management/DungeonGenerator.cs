using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class DungeonGenerator : MonoBehaviour
{
//     private LayoutRoom startingRoom;
//     private LayoutRoom bossRoom;

//     // Temporary Variables (FOR TESTING)
//     [SerializeField]
//     private int totalRooms;

//     [SerializeField]
//     private GameObject[] roomPrefabs;

//     AbstractLayoutGenerator layoutGenerator;

//     // The active room prefabs in the scene.
//     private List<GameObject> activePrefabs;

//     public void RunLayoutGen()
//     {
//         // First clear the existing layout.
//         ClearLayoutGen();
//         layoutGenerator = new BasicLayoutGenerator();
//         LayoutRoomsList rooms = layoutGenerator.GenerateDungeonLayout(totalRooms);

//         // Setting a random origin room
//         startingRoom = rooms.rooms[Random.Range(0, rooms.rooms.Count)];

//         // FINDING THE BOSS ROOM //

//         PathFinder pf = new PathFinder();

//         bossRoom = pf.findBossRoom(rooms, startingRoom.id);

//         // print("Boss room: " + bossRoom.x + "," + bossRoom.y);
//         foreach (LayoutRoom room in rooms.rooms)
//         {
//             //print("Coords: " + room.x + "," + room.y);
//             GenerateRoomPrefab(room);
//             // print("room: " + room.x + "," + room.y);
//         }

//     }

//     internal void ClearLayoutGen()
//     {
//         foreach (var prefab in activePrefabs)
//         {
//             DestroyImmediate(prefab);
//         }

//     }

//     void GenerateRoomPrefab(LayoutRoom room)
//     {
//         float dif = 1.25f;
//         foreach (var rpfb in roomPrefabs)
//         {
//             RoomPrefab rpfb_script = rpfb.GetComponent<RoomPrefab>();

//             if (rpfb_script.roomNorth == room.roomNorth
//             && rpfb_script.roomEast == room.roomEast
//             && rpfb_script.roomSouth == room.roomSouth
//             && rpfb_script.roomWest == room.roomWest)
//             {
//                 GameObject newRoom = Instantiate(rpfb, new Vector3(room.x * dif, room.y * dif, 0),
//                     transform.rotation);

//                 // Add these to the list so they are easy to clear later.
//                 activePrefabs.Add(newRoom);

//                 if (room == startingRoom)
//                 {
//                     newRoom.transform.Find("base").GetComponent<SpriteRenderer>().color = Color.blue;
//                 }
//                 else if (room == bossRoom)
//                 {
//                     newRoom.transform.Find("base").GetComponent<SpriteRenderer>().color = Color.red;
//                 }
//             }
//         }
//     }
}