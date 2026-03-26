using UnityEngine;

public class WindTunnel : MonoBehaviour
{
    [SerializeField] private Vector3 pushDirection;

    //private void OnTriggerStay(Collider other)
    //{
    //    other.attachedRigidbody.linearVelocity += pushDirection;
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerBrain>().InWindTunnel = pushDirection;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerBrain>().InWindTunnel = Vector3.zero;
        }
    }
}
