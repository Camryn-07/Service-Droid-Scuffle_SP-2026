using UnityEngine;

public class FloorActivation : MonoBehaviour
{
    [SerializeField] private Activator activator;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Crate"))
        {
            activator.Activation();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Crate"))
        {
            activator.Activation();
        }
    }
}
