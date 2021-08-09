using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapPainter : MonoBehaviour
{
    // [SerializeField]
    // private Tilemap tilemap;

    // [SerializeField]
    // private TileBase tile;

    // public void PaintFloorTiles(IEnumerable<Vector2Int> tilePositions)
    // {
    //     PaintTiles(tilePositions, tilemap, tile);
    // }

    public void PaintTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile)
    {
        foreach (var position in positions)
        {
            PaintSingleTile(tilemap, tile, position);
        }
    }

    private void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position)
    {
        var tilePosition = tilemap.WorldToCell((Vector3Int)position);
        tilemap.SetTile(tilePosition, tile);
    }
}