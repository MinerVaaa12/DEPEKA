using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterInteractController : MonoBehaviour
{
    CharacterController characterController;
     Rigidbody2D rb2d;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    Character character;
    [SerializeReference] HighlightController highlightController;


    public void Awake()
    {
        characterController = GetComponent<CharacterController>();
        rb2d = GetComponent<Rigidbody2D>();
        character = GetComponent<Character>();
    }

    private void Update()
    {
        Check();
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    private void Check ()
    {
        Vector2 position = rb2d.position + characterController.lastMovementVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);
        foreach (Collider2D c in colliders){
            Interactable hit = c.GetComponent<Interactable>();
            if (hit != null){
                highlightController.Highlight(hit.gameObject);
                return;
            }
        }
        highlightController.Hide();
    }

    private void Interact()
    {
        Vector2 position = rb2d.position + characterController.lastMovementVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach (Collider2D c in colliders){
            Interactable hit = c.GetComponent<Interactable>();
            if (hit != null){
                hit.Interact(character);
                break;
            }
        }
    }
}
