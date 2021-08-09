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

    // private static int roomHeight = 8;
    // private static int roomWidth = 12;

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
        HashSet<Vector2Int> floorTiles = new HashSet<Vector2Int>();

        var startAtHeight = -(roomHeight / 2);
        var startAtWidth = -(roomWidth / 2);
        for (int width = startAtWidth; width < roomWidth / 2; width++)
        {
            for (int height = startAtHeight; height < roomHeight / 2; height++)
            {
                var tileCoords = new Vector2Int(width, height);
                floorTiles.Add(tileCoords);
            }
        }

        // Set coordinates for wall tiles.
        HashSet<Vector2Int> wallTiles = new HashSet<Vector2Int>();

        wallTiles = WallGenerator.GetWalls(floorTiles);

        return new TilePositionTemplate(floorTiles, wallTiles);
    }
}
