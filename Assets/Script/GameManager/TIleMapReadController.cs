using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Tilemaps;

public class TileMapReadController : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    public CropsManager cropsManager;
    
   

    public Vector3Int GetGridPosition(Vector2 position, bool mousePosition)
    {
        Vector3 worldPosition;

        if (mousePosition)
        {
            worldPosition = Camera.main.ScreenToWorldPoint(position);
            worldPosition.z = 0; // penting untuk tilemap 2D
        }
        else
        {
            worldPosition = position;
        }

        return tilemap.WorldToCell(worldPosition);
    }

    // Alias supaya ToolsCharacterController bisa tetap pakai GetTilePosition
    public Vector3Int GetTilePosition(Vector2 position, bool mousePosition)
    {
        return GetGridPosition(position, mousePosition);
    }

    public TileBase GetTileBase(Vector3Int gridPosition)
    {
        return tilemap.GetTile(gridPosition);
    }
}
