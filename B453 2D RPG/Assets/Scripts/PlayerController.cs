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
    public Vector2 facingDir;

    public bool interactInput;
    public float rayCastLength;
    public LayerMask interactLayerMask;

    public void Update()
    {
        if (moveInput.magnitude != 0.0f)
        {
            facingDir = moveInput.normalized;
        }
        
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
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + facingDir, Vector3.up, rayCastLength, interactLayerMask);

        if(hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.name);

            if (hit.collider.gameObject.GetComponent<IConversational>() != null)
            {
                hit.collider.gameObject.GetComponent<IConversational>().StartConversation();
            }
        }
    }
}
