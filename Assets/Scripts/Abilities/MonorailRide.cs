using UnityEngine;
using UnityEngine.InputSystem;

public class MonorailRide : MonoBehaviour
{
    private InputAction attatch;
    [SerializeField] private LayerMask railLayer;
    [SerializeField] private float checkDistance;
    private Transform ActiveRail;
    private bool canAttatch;

    void Start()
    {
        attatch = InputSystem.actions.FindAction("Monorail");
        attatch.performed += AttatchPerformed;
        canAttatch = false;
    }

    private void AttatchPerformed(InputAction.CallbackContext obj)
    {
        if (canAttatch)
        {
            transform.SetParent(ActiveRail);
        }
    }

    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, transform.up, out RaycastHit hit, checkDistance, railLayer))
        {
            canAttatch = true;
            ActiveRail = hit.transform;
        }
        else
        {
            canAttatch = false;
            ActiveRail = null;
        }
    }
}