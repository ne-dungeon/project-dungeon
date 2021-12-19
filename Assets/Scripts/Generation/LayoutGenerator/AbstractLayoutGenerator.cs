using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractLayoutGenerator
{
    public abstract LayoutRoomsList GenerateDungeonLayout(int dungeonNumber, int level, int numRooms);
}
