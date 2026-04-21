using UnityEngine;

public class StickToPlatform : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject carryObject;
    private Vector3 velocity;

    public Vector3 Velocity { get => velocity; set => velocity = value; }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Crate"))
    //    {
    //        // Sets platform as a parent to the player when colliding with it
    //        carryObject = collision.gameObject;
    //        Debug.Log("Carry Object set");
    //        carryObject.transform.SetParent(transform);
    //    }
    //}

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Crate"))
        {
            collision.transform.GetComponent<Rigidbody>().position += velocity;
        }
    }

    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Crate"))
    //    {
    //        // undoes platform parenting when player is no longer touching it
    //        carryObject.transform.SetParent(null);
    //        carryObject = null;
    //        Debug.Log("Carry Object forgot");
    //    }
    //}
}
