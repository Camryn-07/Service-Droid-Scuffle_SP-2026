using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHurt : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float deathPlane;
    [SerializeField] private Transform respawn;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            //bounce the player away from the hazard
            //rb.linearVelocity = new Vector3(-rb.linearVelocity.x, -rb.linearVelocity.y, -rb.linearVelocity.z);
        }
    }

    private void Update()
    {
        if (transform.position.y <= deathPlane)
        {
            transform.position = new Vector3(respawn.position.x, respawn.position.y, respawn.position.z);
        }
    }
}
