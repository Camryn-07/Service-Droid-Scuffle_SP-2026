using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    public Activator activeItem;
    private InputAction activate;
    [SerializeField] private bool canPush;
    private void Start()
    {
        activate = InputSystem.actions.FindAction("Interact");
        activate.started += ActivatePerformed;
        canPush = false;
    }

    private void ActivatePerformed(InputAction.CallbackContext obj)
    {
        if (canPush)
        {
            activeItem.Activation();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Button"))
        {
            canPush = true;
            activeItem = other.gameObject.GetComponent<Activator>();
            activeItem.PressPrompt.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Button"))
        {
            canPush = false;
            if (activeItem != null)
            {
                activeItem.PressPrompt.SetActive(false);
            }
            activeItem = null;
        }
    }

    private void OnDestroy()
    {
        //This line throws a null reference error
        //activate.started -= ActivatePerformed;
    }
}