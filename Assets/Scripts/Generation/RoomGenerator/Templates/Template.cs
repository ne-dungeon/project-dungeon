using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Template : MonoBehaviour
{
    private Theme theme;
    private HashSet<DoorDetails> doors;

    private ThemeTemplates themeTemplates;

    // Tilemaps to affect
    [SerializeField]
    private Tilemap floorTilemap;
    [SerializeField]
    private Tilemap wallTilemap;
    [SerializeField]
    private Tilemap doorTilemap;
    // Tiles to use
    [SerializeField]
    private TileBase floorRuleTile;
    [SerializeField]
    private TileBase wallRuleTile;
    [SerializeField]
    private TileBase doorRuleTile;

    // Test build a template and paint its tiles.
    public void RunGetTemplate()
    {
        var templateTiles = GetTemplate();
        // Paint floor tiles.
        TilemapPainter.PaintTiles(templateTiles.floorTilePositions, floorTilemap, floorRuleTile);
        // Paint wall tiles.
        TilemapPainter.PaintTiles(templateTiles.wallTilePositions, wallTilemap, wallRuleTile);
        // Paint door tiles.
        TilemapPainter.PaintTiles(templateTiles.doorTilePositions, wallTilemap, doorRuleTile);
    }

    public void ClearAllTileMaps()
    {
        TilemapPainter.ClearTiles(floorTilemap);
        TilemapPainter.ClearTiles(wallTilemap);
        TilemapPainter.ClearTiles(doorTilemap);
    }

    // Overload with no parameters for testing purposes, delete (or refactor for 
    // continued testing) once things are working and proper tests are set up.
    public TilePositionTemplate GetTemplate()
    {
        theme = Theme.AbandonedMine;
        doors = new HashSet<DoorDetails>(){new DoorDetails(0, DoorDirection.NORTH, DoorType.Open, 4),
            new DoorDetails(0, DoorDirection.SOUTH, DoorType.Open, -3),
            new DoorDetails(0, DoorDirection.EAST, DoorType.Open, 1),
            new DoorDetails(0, DoorDirection.WEST, DoorType.Open, 2)};
        return GetTemplate(theme, doors);
    }

    public TilePositionTemplate GetTemplate(Theme theme, HashSet<DoorDetails> doors)
    {
        // get template: takes a theme and a door set and picks an appropriate template
        // switch statement, use theme enum, case runs func for theme, func for theme assessess doors and 
        // runs a compatible function in the appropriate theme dungeon 
        // TODO: Factory pattern that uses whichever Theme set we have selected based on parameter

        // TODO: Logic to compare door directions with possible template functions and return which 
        // template functions are valid for this set of doors. Only interested in None vs more than none.
        themeTemplates = new DefaultTemplates();
        return themeTemplates.Get(doors);
    }
}
