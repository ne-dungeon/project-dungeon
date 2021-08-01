using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Creates templates for the Default dungeon theme.
/// </summary>
public class DefaultTemplates : ThemeTemplates
{

    public DefaultTemplates(int roomWidth = 8, int roomHeight = 12) : base(roomWidth, roomHeight) { }

    // private static int roomHeight = 8;
    // private static int roomWidth = 12;

    // Templates applicable to default dungeon theme
    // REturn multiple vectors of various tile types?
    // how to compare template to doors?
    public override HashSet<Vector2Int> DoorsAny()
    {
        // insert code to randomly select one of several templates
        return SolidRoom();
    }

    private HashSet<Vector2Int> SolidRoom()
    {
        HashSet<Vector2Int> floorTiles = new HashSet<Vector2Int>();


        var startAtHeight = -(roomHeight / 2);
        var startAtWidth = -(roomWidth / 2);
        for (int width = startAtWidth; width < roomWidth / 2; width++)
        {
            for (int height = startAtHeight; height < roomHeight / 2; height++)
            {
                var tileCoords = new Vector2Int(width, height);
                Debug.Log(tileCoords);
                floorTiles.Add(tileCoords);
            }
        }

        return floorTiles;
    }
}
