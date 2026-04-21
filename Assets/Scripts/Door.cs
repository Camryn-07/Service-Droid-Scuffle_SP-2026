using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Vector3 finalPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, finalPosition, moveSpeed * Time.deltaTime);
    }
}
