using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Static methods to help build templates.
/// </summary>
public static class TemplateHelpers
{
    // Generates a HashSet of coordinates for placing tiles on a tilemap.
    public static HashSet<Vector2Int> FillRectangularCoordinates(int totalHeight, int totalWidth)
    {
        HashSet<Vector2Int> positions = new HashSet<Vector2Int>();

        var startAtHeight = -(totalHeight / 2);
        var startAtWidth = -(totalWidth / 2);
        for (int width = startAtWidth; width < totalWidth / 2; width++)
        {
            for (int height = startAtHeight; height < totalHeight / 2; height++)
            {
                var tileCoords = new Vector2Int(width, height);
                positions.Add(tileCoords);
            }
        }
        return positions;
    }
}
