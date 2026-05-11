using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathplane : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float deathPlane;
    [SerializeField] private Vector3 respawn;

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
            transform.position = respawn;
        }
    }
}
