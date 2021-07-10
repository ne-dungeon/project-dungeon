using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct RoomDetails
{
    public bool startRoom;
    public DoorDirections doors;
    public byte difficultyDepth;
    public byte minions;
    public byte miniBosses;
    public bool levelBoss;
    public TreasureType treasure;
}

public struct DoorDirections
{
    DoorType north;
    DoorType south;
    DoorType east;
    DoorType west;
}

public enum DoorType
{
    None,
    Open,
    Locked,
    Breakable,
    Boss
}

public enum TreasureType
{
    None,
    Minor,
    Major,
    Special,
    Key,
    BossKey
}