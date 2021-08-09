using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct TilePositionTemplate 
{
    public HashSet<Vector2Int> floorTilePositions;
    public HashSet<Vector2Int> wallTilePositions;

    public TilePositionTemplate(HashSet<Vector2Int> floorPositions, HashSet<Vector2Int> wallPositions) {
        this.floorTilePositions = floorPositions;
        this.wallTilePositions = wallPositions;
    }
}
