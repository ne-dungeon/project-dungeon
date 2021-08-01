using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Template : MonoBehaviour
{
    private Theme theme;
    private DoorDetails[] doors;

    private ThemeTemplates themeTemplates;

    // Temp reference 
    [SerializeField]
    private TilemapVisualizer tilemapVisualizer;

    public void RunGetTemplate()
    {
        var templateTiles = GetTemplate();
        Debug.Log("got tiles");
        tilemapVisualizer.PaintFloorTiles(templateTiles);
    }

    // Overload with no parameters for testing purposes, delete once things are working and proper tests are set up.
    public HashSet<Vector2Int> GetTemplate()
    {
        theme = Theme.Default;
        doors = new DoorDetails[] {
            new DoorDetails(0, DoorDirection.NORTH, DoorType.Open),
            new DoorDetails(0, DoorDirection.SOUTH, DoorType.Open),
            new DoorDetails(0, DoorDirection.EAST, DoorType.Open),
            new DoorDetails(0, DoorDirection.WEST, DoorType.Open)
            };
        return GetTemplate(theme, doors);
    }

    public HashSet<Vector2Int> GetTemplate(Theme theme, DoorDetails[] doors)
    {
        // get template: takes a theme and a door set and picks an appropriate template
        // switch statement, use theme enum, case runs func for theme, func for theme assessess doors and 
        // runs a compatible function in the appropriate theme dungeon 
        // TODO: Factory pattern that uses whichever Theme set we have selected based on parameter

        // TODO: Logic to compare door directions with possible template functions and return which 
        // template functions are valid for this set of doors. Only interested in None vs more than none.
        themeTemplates = new DefaultTemplates();
        return themeTemplates.DoorsAny();
    }
}
