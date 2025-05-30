using UnityEngine;

public class NPCTalk : Interactable
{
    [SerializeField] DialogueContainer dialogue;

    public override void Interact(Character character)
    {
        GameManager.instance.dialogueSystem.Initialize(dialogue); 
    } 
}
