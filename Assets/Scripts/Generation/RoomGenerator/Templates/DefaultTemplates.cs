using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Creates tile position templates for the Default dungeon theme.
/// </summary>
public class DefaultTemplates : ThemeTemplates
{
    // Insert code to get and assign to variables appropriate Tiles for this room's floors, walls, etc 
    // OR: Ruletile?

    // Odd values for room width and height may produce unexpected behavior. We can 
    // write code for this in the future but at the moment code assumes all values will 
    // be even.
    public DefaultTemplates(int roomWidth = 8, int roomHeight = 12) : base(roomWidth, roomHeight) { }

    // Templates applicable to default dungeon theme
    // REturn multiple vectors of various tile types?
    // how to compare template to doors?
    public override TilePositionTemplate Get(HashSet<DoorDetails> doors)
    {
        // insert code to randomly select one of several templates
        return SolidRoom(doors);
    }

    private TilePositionTemplate SolidRoom(HashSet<DoorDetails> doors)
    {
        // Get coordinates for floor tiles.
        HashSet<Vector2Int> floorTiles = TemplateHelpers.FillRectangularCoordinates(roomHeight, roomWidth);

        // Get coordinates for wall tiles.
        HashSet<Vector2Int> wallTiles = WallGenerator.GetWalls(floorTiles, roomHeight, roomWidth);
        
        // Get coordinates for door tiles.
        HashSet<Vector2Int> doorTiles = DoorGenerator.GetDoors(doors, roomHeight, roomWidth);

        return new TilePositionTemplate(floorTiles, wallTiles, doorTiles);
    }
}
