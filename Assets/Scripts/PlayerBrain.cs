using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBrain : MonoBehaviour
{
    private InputAction move;
    private Vector3 playerMovement;
    [SerializeField] private float playerSpeed;
    private Rigidbody rb;
    private InputAction interact;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        move = InputSystem.actions.FindAction("Move");
        move.performed += MovePerformed;
        move.canceled += MoveCanceled;
        interact = InputSystem.actions.FindAction("Interact");
        interact.performed += InteractPerformed;

    }

    private void MovePerformed(InputAction.CallbackContext obj)
    {
        playerMovement.x = obj.ReadValue<Vector2>().x * playerSpeed;
        playerMovement.z = obj.ReadValue<Vector2>().y * playerSpeed;
    }
    private void MoveCanceled(InputAction.CallbackContext obj)
    {
        playerMovement = Vector3.zero;
    }

    private void InteractPerformed(InputAction.CallbackContext obj)
    {
        Debug.Log("Interactions not added yet :3");
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector3(playerMovement.x, rb.linearVelocity.y, playerMovement.z);
    }
}
