using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// A simple struct to hold the major details of a room to be generated. Passed
/// from the Dungeon Generator to the Room Generator to create each room.
public struct RoomDetails
{
    // The theme of the dungeon being generated.
    public Theme theme;
    // Whether or not the room is the start room of the level, ie, should have stairs out.
    public bool startRoom;
    // Which doors and of what type should be generated.
    public DoorDirections doors;
    // How deep does it go.....?
    public byte difficultyDepth;
    // Lower level, lower difficulty enemies.
    public byte minions;
    // Higher level enemies.
    public byte miniBosses;
    // Is this the room that has the level's boss?
    public bool levelBoss;
    // What kind of loot are we getting here? :D
    public TreasureType treasure;
}

/// Each possible door has a type.
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

// We will add more themes once we get beyond the initial dungeon.
public enum Theme
{
    Default
}
