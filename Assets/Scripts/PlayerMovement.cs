using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private InputAction move;
    private Vector3 playerMovement;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float rotationSpeed;
    private Rigidbody rb;
    private InputAction interact;
    private Vector3 inWindTunnel;

    public Vector3 InWindTunnel { get => inWindTunnel; set => inWindTunnel = value; }

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
    void FixedUpdate()
    {

            rb.linearVelocity = new Vector3
               (transform.forward.x * playerMovement.z + inWindTunnel.x,
               rb.linearVelocity.y + inWindTunnel.y,
               transform.forward.z * playerMovement.z + inWindTunnel.z);

        transform.Rotate(new Vector3(0, playerMovement.x * rotationSpeed, 0));
    }

    public void OnMonorail()
    {

    }
    public void OffMonorail()
    {

    }

    private void OnDestroy()
    {
        move.performed -= MovePerformed;
        move.canceled -= MoveCanceled;
        interact.performed -= InteractPerformed;
    }
}
