using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Vector3 respawnPoint;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        { 
            transform.position = respawnPoint;
        }
    }
}
