using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Tile Data")]

public class TileData : ScriptableObject
{
    public List<TileBase> tiles;

    public bool plowable;
}
