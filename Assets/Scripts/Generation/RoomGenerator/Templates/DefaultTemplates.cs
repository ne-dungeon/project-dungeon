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

    public DefaultTemplates(int roomWidth = 8, int roomHeight = 12) : base(roomWidth, roomHeight) { }

    // Templates applicable to default dungeon theme
    // REturn multiple vectors of various tile types?
    // how to compare template to doors?
    public override TilePositionTemplate Get()
    {
        // insert code to randomly select one of several templates
        return SolidRoom();
    }

    private TilePositionTemplate SolidRoom()
    {
        // Get coordinates for floor tiles.
        HashSet<Vector2Int> floorTiles = TemplateHelpers.FillRectangularCoordinates(roomHeight, roomWidth);

        // Get coordinates for wall tiles.
        HashSet<Vector2Int> wallTiles = WallGenerator.GetWalls(floorTiles, roomHeight, roomWidth);

        // // Get the total area that we do not want overridden with background tiles.
        // var gameSceneTiles = new HashSet<Vector2Int> (floorTiles);
        // gameSceneTiles.UnionWith(wallTiles);
        // // Then get the background tile coordinates.
        // HashSet<Vector2Int> wallOverrideTiles = WallGenerator.GetWallOverrides(gameSceneTiles, roomHeight, roomWidth);

        return new TilePositionTemplate(floorTiles, wallTiles);
    }
}
