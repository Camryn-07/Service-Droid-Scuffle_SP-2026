using UnityEngine;
using UnityEngine.InputSystem;

public class MagnetPull : MonoBehaviour
{
    private InputAction pull;
    [SerializeField] private float checkDistance;
    private GameObject pullObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pull = InputSystem.actions.FindAction("");
        pull.performed += PullPerformed;
        pull.canceled += PullCanceled;
    }

    private void PullPerformed(InputAction.CallbackContext obj)
    {
        if (Physics.Raycast(transform.position, transform.forward, checkDistance, 6))
        {
            //pullObject = Physics.Raycast(transform.position, transform.forward, checkDistance, 6);
            //pull the box towaards the player
        }
    }

    private void PullCanceled(InputAction.CallbackContext obj)
    {
        //throw new System.NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
