using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Variables")]
    public int moveSpeed;
    public Rigidbody2D rb;
    public Vector2 moveInput;
    public bool interactInput;

    public void Update()
    {
        if (interactInput)
        {
            interactInput = false;
            TryInteract();
        }
    }

    public void FixedUpdate()
    {
        rb.velocity = moveInput.normalized * moveSpeed;
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            interactInput = true;
        }
    }

    private void TryInteract()
    {
        Debug.Log("Pressed interact button");
    }
}
