using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject player;
    public ItemContainer inventoryContainer;
    public ItemDragAndDropController dragandDropController;
    public DayTimeController timeController;
    public DialogueSystem dialogueSystem;

    private void Awake()
    {
        instance = this;
    }
}