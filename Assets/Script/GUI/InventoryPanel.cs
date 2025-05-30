using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : ItemPanel
{
    public override void OnClick(int id)
    {
        GameManager.instance.dragandDropController.OnClick(inventory.slots[id]);
        Show();
    }
}
