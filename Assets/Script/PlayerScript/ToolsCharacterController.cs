using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ToolsCharacterController : MonoBehaviour
{
    CharacterController character;
    Rigidbody2D rb2d;

    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    [SerializeField] MarkerManager markerManager;
    Animator animator;
    ToolBarController toolBarController;
    [SerializeField] TileMapReadController tileMapReadcontroller;
    [SerializeField] float maxDistance = 1.5f;
    [SerializeField] ToolAction onTilePickUp;
    

    Vector3Int selectedTilePosition;
    bool selectable;

    private void Awake()
    {
        character = GetComponent<CharacterController>();
        rb2d = GetComponent<Rigidbody2D>();
        toolBarController = GetComponent<ToolBarController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        SelecTile();
        CanSelectCheck();
        Marker();

        if (Input.GetMouseButtonDown(0))
        {
            if (UseToolWorld() == true)
            {
                return;
            }
            UseToolGrid();
        }
    }

    private void SelecTile()
    {
        selectedTilePosition = tileMapReadcontroller.GetTilePosition(Input.mousePosition, true);
    }

    void CanSelectCheck()
    {
        Vector2 characterPosition = transform.position;
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        selectable = Vector2.Distance(characterPosition, mouseWorldPosition) < maxDistance;
        markerManager.Show(selectable);
    }

    private void Marker()
    {
        markerManager.markedCellPosition = selectedTilePosition;
    }

    private bool UseToolWorld()
    {
        Vector2 position = rb2d.position + character.lastMovementVector * offsetDistance;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        Item item = toolBarController.GetItem;
        if (item == null) { return false; }
        if (item.onAction == null) { return false; }


        animator.SetTrigger("act");
        bool complete = item.onAction.OnApply(position);

        if (complete == true)
            {
                if (item.onItemUsed != null)
                {
                    item.onItemUsed.OnItemUsed(item, GameManager.instance.inventoryContainer);
                }  
            }
        
        return complete;
    }

    private void UseToolGrid()
    {
        if (selectable)
        {
            Item item = toolBarController.GetItem;
            if (item == null)
            {
                PickUpTile();
                return;
            }
            if (item.onTileMapAction == null) { return; }

            animator.SetTrigger("act");
            bool complete = item.onTileMapAction.OnApplyToTileMap(selectedTilePosition, tileMapReadcontroller, item);

            if (complete == true)
            {
                if (item.onItemUsed != null)
                {
                    item.onItemUsed.OnItemUsed(item, GameManager.instance.inventoryContainer);
                }  
            }
        }
    }

    private void PickUpTile()
    {
        if (onTilePickUp == null)
        {
            return;
        }
        onTilePickUp.OnApplyToTileMap(selectedTilePosition, tileMapReadcontroller, null);
    }
}