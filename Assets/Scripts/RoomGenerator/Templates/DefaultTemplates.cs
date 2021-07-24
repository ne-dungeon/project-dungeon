using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Creates templates for the Default dungeon theme.
/// </summary>
public static class DefaultTemplates
{
    private static int roomHeight = 10;
    private static int roomWidth = 10;

    // Templates applicable to default dungeon theme
    // REturn multiple vectors of various tile types?
    // how to compare template to doors?
    public static HashSet<Vector2Int> DoorsAny() {
        // insert code to randomly select one of several templates
        return SolidRoom();
    }

    private static HashSet<Vector2Int> SolidRoom() {
        HashSet<Vector2Int> floorTiles = new HashSet<Vector2Int>();

        
         var startAtHeight = -(roomHeight/2);
         var startAtWidth = -(roomWidth/2);
         for (int width = startAtWidth; width < roomWidth/2; width++)
         {
             for (int height = startAtHeight; height < roomHeight/2; height++)
             {
                 var tileCoords = new Vector2Int(width, height);
                 Debug.Log(tileCoords);
                 floorTiles.Add(tileCoords);
                //  floorTiles.Add(new Vector2Int(width, height));
             }
         }

         return floorTiles;
    }
}
