using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// A simple struct to hold the major details of a room to be generated. Passed
/// from the Dungeon Generator to the Room Generator to create each room.
/// </summary>
public struct RoomDetails
{
    public RoomDetails(
        int id, DoorDetails[] doors, Theme theme = Theme.Default, 
        int roomHeight = 8, int roomWidth = 12, 
        bool startRoom = false, bool goesDown = false,
        byte difficultyDepth = 0, byte minions = 0,
        byte miniBosses = 0, byte nonHostiles = 0,
        bool levelBoss = false, Puzzle puzzle = Puzzle.None,
        TreasureType treasure = TreasureType.None )
    {
        this.theme = theme;
        this.roomHeight = roomHeight;
        this.roomWidth = roomWidth;
        this.startRoom = startRoom;
        this.goesDown = goesDown;
        this.doors = doors;
        this.difficultyDepth = difficultyDepth;
        this.minions = minions;
        this.miniBosses = miniBosses;
        this.nonHostiles = nonHostiles;
        this.levelBoss = levelBoss;
        this.puzzle = puzzle;
        this.treasure = treasure;
        this.id = id;
    }
    // The theme of the dungeon being generated.
    public Theme theme;
    // The size of the room in grid tiles.
    public int roomHeight;
    public int roomWidth;
    // Whether or not the room is the start room of the level, ie, should have stairs out.
    public bool startRoom;
    // Is this the room with the stairs down?
    public bool goesDown;
    // Which doors and of what type should be generated.
    public DoorDetails[] doors;
    // public DoorDirections doors;
    // How deep does it go.....?
    public byte difficultyDepth;
    // Lower level, lower difficulty enemies.
    public byte minions;
    // Higher level enemies.
    public byte miniBosses;
    // Non hostile npcs depending on dungeon theme, such as dwarven miners.
    // Mutually exclusive with minions/minibosses.
    public byte nonHostiles;
    // Is this the room that has the level's boss? (Possibly mutually exclusive 
    // with all other npc types?)
    public bool levelBoss;
    // Is there a puzzle, and if so what kind? Most puzzles should not occur in rooms
    // without treasure, unless it is to open a door in the room.
    public Puzzle puzzle;
    // What kind of loot are we getting here? :D
    public TreasureType treasure;
    public int id;
    // Coordinates?
    // public SomeType coordinates;
}

/// <summary>Door with a direction (ie, which wall it goes on), a type, and a 
/// position in the wall.</summary>
public struct DoorDetails
{
    public DoorDetails(int goesToID, DoorDirection direction, DoorType type, int position = 0)
    {
        this.goesToID = goesToID;
        this.direction = direction;
        this.type = type;
        this.position = position;
    }
    int goesToID;
    DoorDirection direction;
    DoorType type;
    // 0 is centered in the wall, position will be added to 0 to determine 
    // final location in wall. Specifics of +/- results depend on axis (direction).
    int position;
}

public enum DoorDirection { NORTH, SOUTH, EAST, WEST }

// public struct DoorDirections
// {
//     public DoorDirections(DoorType n, DoorType s, DoorType e, DoorType w)
//     {
//         north = n;
//         south = s;
//         east = e;
//         west = w;
//     }
//     DoorType north;
//     DoorType south;
//     DoorType east;
//     DoorType west;
// }

/// <summary>Type of door or none.</summary>
public enum DoorType
{
    None,
    Open,
    Breakable,
    Broken,
    Locked,
    Unlocked,
    Boss,
    BossUnlocked
}

/// <summary>Type of treasure or none.</summary>
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
/// <summary>Zone or theme of dungeon being generated.</summary>
public enum Theme
{
    Default
}

/// <summary>Type of puzzle to include in room or none.</summary>
public enum Puzzle
{
    None
}