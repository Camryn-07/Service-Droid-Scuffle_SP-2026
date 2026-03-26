using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            //bounce the player away from the hazard
            //rb.linearVelocity = new Vector3(-rb.linearVelocity.x, -rb.linearVelocity.y, -rb.linearVelocity.z);
        }
    }
}
