using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// A class to hold the major details of a room to be generated. Used to pass 
/// information from the Layout and Pathfinding generators to the room generator
/// in order to create each room. 
/// </summary>
[CreateAssetMenu(fileName = "RoomDetails_", menuName = "Generation/RoomDetails")]
public class RoomDetails : ScriptableObject
{
    // public RoomDetails(
    //     int id, HashSet<DoorDetails> doors, Theme theme = Theme.Default, 
    //     int roomHeight = 8, int roomWidth = 12, 
    //     bool startRoom = false, bool goesDown = false,
    //     byte difficultyDepth = 0, byte minions = 0,
    //     byte miniBosses = 0, byte nonHostiles = 0,
    //     bool levelBoss = false, Puzzle puzzle = Puzzle.None,
    //     TreasureType treasure = TreasureType.None )
    // {
    //     this.theme = theme;
    //     this.roomHeight = roomHeight;
    //     this.roomWidth = roomWidth;
    //     this.startRoom = startRoom;
    //     this.goesDown = goesDown;
    //     this.doors = doors;
    //     this.difficultyDepth = difficultyDepth;
    //     this.minions = minions;
    //     this.miniBosses = miniBosses;
    //     this.nonHostiles = nonHostiles;
    //     this.levelBoss = levelBoss;
    //     this.puzzle = puzzle;
    //     this.treasure = treasure;
    //     this.id = id;
    // }
    // Whether the room has been generated from the details yet or not.
    private bool _generated = false;
    public bool Generated
    {
        get { return _generated; }
        private set { _generated = value; }
    }
    // The theme of the dungeon being generated.
    public Theme theme = Theme.Default;
    // The size of the room in grid tiles.
    public int roomHeight = 8;
    public int roomWidth = 12;
    // Whether or not the room is the start room of the level, ie, should have stairs out.
    public bool startRoom = false;
    // Is this the room with the stairs down?
    public bool goesDown = false;
    // Which doors and of what type should be generated.
    public HashSet<DoorDetails> doors;
    // public DoorDirections doors;
    // How deep does it go.....?
    public byte difficultyDepth = 0;
    // Lower level, lower difficulty enemies.
    public byte minions = 0;
    // Higher level enemies.
    public byte miniBosses = 0;
    // Non hostile npcs depending on dungeon theme, such as dwarven miners.
    // Mutually exclusive with minions/minibosses.
    public byte nonHostiles = 0;
    // Is this the room that has the level's boss? (Possibly mutually exclusive 
    // with all other npc types?)
    public bool levelBoss = false;
    // Is there a puzzle, and if so what kind? Most puzzles should not occur in rooms
    // without treasure, unless it is to open a door in the room.
    public Puzzle puzzle = Puzzle.None;
    // What kind of loot are we getting here? :D
    public TreasureType treasure = TreasureType.None;
    public int id;
    // Coordinates?
    // public SomeType coordinates;

    // Move to generated room class/struct that contains all the tilemap templates, etc.
    public bool validateGeneration()
    {
        // Add code to verify that everything that needs to be generated for the room to be a room has been generated.
        _generated = true;
        return _generated;
    }
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
    // Every door should have a paired door that is its opposite.
    public int goesToID;
    // The wall of the room that the door goes to.
    public DoorDirection direction;
    public DoorType type;
    // Position is the positive coordinate position of door on the wall. 
    // Example: an east facing wall of length 8. Coordinates on the wall range from 
    // -4 to +3 y.  A door at position 0 would occupy tiles -1 and 0 y.
    // Defaults to 0 as this is the center of the wall.
    public int position;
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