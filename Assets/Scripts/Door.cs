using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Vector3 endPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
        transform.position = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPosition, moveSpeed * Time.deltaTime);
    }

    //use on enable, start and end points, and two opposite moving door objects
    //doors snap to their start point on enable and quickly move to their end point
    //the on enable resets the doors back to their start positions

}
