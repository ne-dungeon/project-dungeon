using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Creates templates for the Default dungeon theme.
/// </summary>
public class DefaultTemplates : ThemeTemplates
{
    // Insert code to get and assign to variables appropriate Tiles for this room's floors, walls, etc 
    // OR: Ruletile?

    public DefaultTemplates(int roomWidth = 8, int roomHeight = 12) : base(roomWidth, roomHeight) { }

    // Templates applicable to default dungeon theme
    // REturn multiple vectors of various tile types?
    // how to compare template to doors?
    public override TilePositionTemplate DoorsAny()
    {
        // insert code to randomly select one of several templates
        return SolidRoom();
    }

    private TilePositionTemplate SolidRoom()
    {
        // Set coordinates for floor tiles.
        HashSet<Vector2Int> floorTiles = TemplateHelpers.FillRectangularCoordinates(roomHeight, roomWidth);

        // Set coordinates for wall tiles.
        HashSet<Vector2Int> wallTiles = WallGenerator.GetWalls(floorTiles, roomHeight, roomWidth);

        return new TilePositionTemplate(floorTiles, wallTiles);
    }
}
