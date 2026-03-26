using UnityEngine;

public class MovingPlatformBrain : MonoBehaviour
{
    [SerializeField] private GameObject[] movePoints;
    [SerializeField] private float moveSpeed;
    private int currentIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Check distance between object and next point
        if (Vector3.Distance(transform.position, movePoints[currentIndex].transform.position) < 0.1f)
        {
            currentIndex++;

            // reset index once at the end
            if (currentIndex >= movePoints.Length)
            {
                currentIndex = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, movePoints[currentIndex].transform.position,
            moveSpeed * Time.deltaTime);
    }
}
