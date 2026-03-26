using UnityEngine;

public class StickToPlatform : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Sets platform as a parent to the player when colliding with it
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // undoes platform parenting when player is no longer touching it
            collision.gameObject.transform.SetParent(null);
        }
    }
}
