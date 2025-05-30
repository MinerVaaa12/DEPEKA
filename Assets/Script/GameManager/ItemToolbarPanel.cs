using System;
using UnityEngine;

public class ItemToolbarPanel : ItemPanel
{
    [SerializeField] ToolBarController toolBarController;

    protected override void Start()
    {
        base.Start();
        Init();
        toolBarController.onChange += Highlight;
    }

    public override void OnClick(int id)
    {
        toolBarController.Set(id);  
        Highlight(id);
    }

    int currentSelectedTool;

    public void Highlight(int id)
    {
        buttons[currentSelectedTool].Highlight(false);
        currentSelectedTool = id;
        buttons[currentSelectedTool].Highlight(true);
    }
}
