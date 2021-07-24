using UnityEngine;


class DungeonGenerator : MonoBehaviour
{
    void Start()
    {
        DungeonLayoutGenerator dlg = new DungeonLayoutGenerator();
        List<Room> rooms = dlg.GenerateDungeonLayout(5);

        int bossRoomId = findBossRoom();
        Room bossRoom = roomById(bossRoomId);

        foreach (Room room in rooms)
        {
            print(room.x, room.y);
        }

        print("Boss room:");
        print(bossRoom.x, bossRoom.y);
    }
}