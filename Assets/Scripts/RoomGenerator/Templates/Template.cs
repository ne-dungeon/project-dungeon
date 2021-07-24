using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Template : MonoBehaviour
{
    private Theme theme;
    private DoorDirections doorDirections;

    // Temp reference 
    [SerializeField]
    private TilemapVisualizer tilemapVisualizer;

    public void RunGetTemplate()
    {
        var templateTiles = GetTemplate();
        tilemapVisualizer.PaintFloorTiles(templateTiles);
    }

    // Overload with no parameters for testing purposes, delete once things are working and proper tests are set up.
    public HashSet<Vector2Int> GetTemplate() {
        theme = Theme.Default;
        doorDirections = new DoorDirections(DoorType.Open, DoorType.Open, DoorType.Open, DoorType.Open);
        return GetTemplate(theme, doorDirections);
    }

    public HashSet<Vector2Int> GetTemplate(Theme theme, DoorDirections doorDirections)
    {
        // get template: takes a theme and a door set and picks an appropriate template
        // switch statement, use theme enum, case runs func for theme, func for theme assessess doors and 
        // runs a compatible function in the appropriate theme dungeon 
        // TODO: Factory pattern that uses whichever Theme set we have selected based on parameter

        // TODO: Logic to compare door directions with possible template functions and return which 
        // template functions are valid for this set of doors. Only interested in None vs more than none.

        return DefaultTemplates.DoorsAny();
    }
}

// abstract class ThemeTemplates
// {
//     // TODO 
// }

// How to make a parent class that template generators must adhere to/inherit from?