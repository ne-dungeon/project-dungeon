using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct TilePositionTemplate 
{
    public HashSet<Vector2Int> floorTilePositions;
    public HashSet<Vector2Int> wallTilePositions;
    // public HashSet<Vector2Int> wallOverridePositions;

    public TilePositionTemplate(HashSet<Vector2Int> floorPositions,
                                HashSet<Vector2Int> wallPositions) {
                                // HashSet<Vector2Int> wallOverridePositions) {
        this.floorTilePositions = floorPositions;
        this.wallTilePositions = wallPositions;
        // this.wallOverridePositions = wallOverridePositions;
    }
}
