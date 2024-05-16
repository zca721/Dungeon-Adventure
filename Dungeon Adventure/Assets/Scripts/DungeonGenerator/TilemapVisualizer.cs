// Zachary Anderson

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapVisualizer : MonoBehaviour
{
    [SerializeField]
    private Tilemap floorTilemap, wallTilemap;
    [SerializeField]
    private TileBase floor, topWall, rightWall, leftWall, bottomWall, fullWall,
    leftTurnWall, rightTurnWall, leftTurnWallSpecial, rightTurnWallSpecial,
    bottomLeftWall, bottomRightWall, topLeftWall, topRightWall;

    public void PaintFloorTiles(IEnumerable<Vector2Int> floorPositions) {
        PaintTiles(floorPositions, floorTilemap, floor);
    }

    private void PaintTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile)
    {
        foreach (var position in positions)
        {
            PaintSingleTile(tilemap, tile, position);
        }
    }

    internal void PaintSingleBasicWall(Vector2Int position, string binaryType)
    {
        Debug.Log(position + " Type: " + binaryType);
        int typeAsInt = Convert.ToInt32(binaryType, 2); // Converts binary number to an int
        TileBase tile = null;
        if (WallTypesHelper.wallTop.Contains(typeAsInt)) {
            tile = topWall;
        } else if (WallTypesHelper.wallSideRight.Contains(typeAsInt)) {
            tile = rightWall;
        } else if (WallTypesHelper.wallSideLeft.Contains(typeAsInt)) {
            tile = leftWall;
        } else if (WallTypesHelper.wallBottom.Contains(typeAsInt)) {
            tile = bottomWall;
        } else if (WallTypesHelper.wallFull.Contains(typeAsInt)) {
            tile = fullWall;
        }

        if (tile != null)
            PaintSingleTile(wallTilemap, tile, position);
    }

    private void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position)
    {
        var tilePosition = tilemap.WorldToCell((Vector3Int)position);
        tilemap.SetTile(tilePosition, tile);
    }

    public void Clear() {
        floorTilemap.ClearAllTiles();
        wallTilemap.ClearAllTiles();
    }

    internal void PaintSingleCornerWall(Vector2Int position, string binaryType)
    {
        int typeAsInt = Convert.ToInt32(binaryType, 2); // Converts binary number to an int
        TileBase tile = null;

        if (WallTypesHelper.wallInnerCornerDownLeft.Contains(typeAsInt)) {
            tile = leftTurnWall;
        } else if (WallTypesHelper.wallInnerCornerDownRight.Contains(typeAsInt)) {
            tile = rightTurnWall;
        } else if (WallTypesHelper.wallDiagonalCornerDownLeft.Contains(typeAsInt)) {
            tile = bottomLeftWall;
        } else if (WallTypesHelper.wallDiagonalCornerDownRight.Contains(typeAsInt)) {
            tile = bottomRightWall;
        } else if (WallTypesHelper.wallDiagonalCornerUpLeft.Contains(typeAsInt)) {
            tile = topLeftWall;
        } else if (WallTypesHelper.wallDiagonalCornerUpRight.Contains(typeAsInt)) {
            tile = topRightWall;
        } else if (WallTypesHelper.wallFullEightDirections.Contains(typeAsInt)) {
            tile = fullWall;
        } else if (WallTypesHelper.wallBottomEightDirections.Contains(typeAsInt)) {
            tile = bottomWall;
        }

        if (tile != null)
            PaintSingleTile(wallTilemap, tile, position);
    }

    // Method Debug Test***** Works!!!
    internal void PaintSingleCornerWallSpecialCase (Vector2Int position, string binaryType)
    {
        int typeAsInt = Convert.ToInt32(binaryType, 2); // Converts binary number to an int
        TileBase tile = null;

        if (WallTypesHelper.wallInnerCornerDownLeftSpecial.Contains(typeAsInt)) {
            tile = leftTurnWall;
        } else if (WallTypesHelper.wallInnerCornerDownRightSpecial.Contains(typeAsInt)) {
            tile = rightTurnWall;
        }

        if (tile != null)
            PaintSingleTile(wallTilemap, tile, position);
    }
}
