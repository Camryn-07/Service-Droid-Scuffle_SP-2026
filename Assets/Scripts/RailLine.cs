using UnityEngine;

public class RailLine : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform startLocation;
    [SerializeField] private Transform endLocation;
    private GameObject player;
    private Rigidbody playerRB;
    private PlayerMovement PM;
    void FixedUpdate()
    {
        if (transform.childCount > 0)
        {
            player = transform.GetChild(0).gameObject;
            playerRB = player.GetComponent<Rigidbody>();
            playerRB.linearVelocity = Vector3.zero;
            playerRB.constraints = RigidbodyConstraints.FreezePositionY;
            playerRB.freezeRotation = true;
            PM = playerRB.GetComponent<PlayerMovement>();
            PM.enabled = false;
            
            if (Vector3.Distance(transform.position, endLocation.position) < 0.1f)
            {
                playerRB.constraints = RigidbodyConstraints.None;
                playerRB.freezeRotation = true;
                PM.enabled = true;
                player.transform.SetParent(null);
                transform.position = startLocation.position;
            }
            transform.position = Vector3.MoveTowards(transform.position,
                endLocation.position, moveSpeed * Time.deltaTime);
        }
    }
}