using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class MagnetPull : MonoBehaviour
{
    private InputAction pull;
    private bool pulling;
    [SerializeField] private float checkDistance;
    [SerializeField] private float magnetForce;
    [SerializeField] private LayerMask magnetLayer;
    [SerializeField] private TMP_Text controlsText;
    [SerializeField] private GameObject magnetBeam;
    private Rigidbody pulledObject;
    [SerializeField] private PlayerMovement PM;
    private bool activated = false;
    [SerializeField] private AudioSource magnetSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        activated = true;
        pull = InputSystem.actions.FindAction("Magnet");
        pull.performed += PullPerformed;
        pull.canceled += PullCanceled;
        //controlsText.text = controlsText.text + "Magnet: Q     ";
    }

    private void PullPerformed(InputAction.CallbackContext obj)
    {
        magnetBeam.SetActive(true);
        magnetSound.Play();
        pulling = true;
        PM.RotationSpeed = 0.1f;
    }

    private void PullCanceled(InputAction.CallbackContext obj)
    {
        magnetBeam.SetActive(false);
        magnetSound.Stop();
        pulling = false;
        PM.RotationSpeed = 0.25f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (pulling)
        {
            if (pulledObject == null && Physics.Raycast(transform.position, transform.forward, out RaycastHit hit,
                    checkDistance, magnetLayer))
            {
                pulledObject = hit.rigidbody;
                //pull the box towaards the player
                pulledObject.useGravity = false;
            }
            else if (pulledObject != null)
            {

                Vector3 direction = transform.position - pulledObject.transform.position;
                direction.Normalize();
                pulledObject.AddForce(direction * magnetForce, ForceMode.Impulse);
            }
        }
        else
        {
            if (pulledObject != null)
            {
                pulledObject.useGravity = true;
                pulledObject = null;
            }
        }
    }

    private void OnDestroy()
    {
        if (activated)
        {
            pull.performed -= PullPerformed;
            pull.canceled -= PullCanceled;
        }
    }
}