using UnityEngine;

[CreateAssetMenu(menuName ="Data/ToolAction/Harvest")]
public class TilePickUpAction : ToolAction
{
    public override bool OnApplyToTileMap(Vector3Int gridPosition, TileMapReadController tileMapReadController, Item item)
    {
        tileMapReadController.cropsManager.PickUp(gridPosition);
        return true;
    }
}
