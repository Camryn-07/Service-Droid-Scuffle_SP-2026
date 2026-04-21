using System.Collections;
using UnityEngine;

public class MovingPlatformBrain : MonoBehaviour
{
    [SerializeField] private GameObject[] movePoints;
    [SerializeField] private float moveSpeed;
    private int currentIndex;
    [SerializeField] private float pauseTime;
    [SerializeField] private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentIndex = 0;
    }
    private void OnEnable()
    {
        StartCoroutine(MoveAndPause());
    }

    private IEnumerator MoveAndPause()
    {
        while (true)
        {
            // Check distance between object and next point
            if (Vector3.Distance(rb.position, movePoints[currentIndex].transform.position) < 0.1f)
            {
                rb.GetComponent<StickToPlatform>().Velocity = Vector3.zero;
                yield return new WaitForSeconds(pauseTime);

                currentIndex++;

                // reset index once at the end
                if (currentIndex >= movePoints.Length)
                {
                    currentIndex = 0;
                }
            }

            Vector3 oldPosition = rb.position;
            rb.position = (Vector3.MoveTowards(rb.position, movePoints[currentIndex].transform.position,
                moveSpeed * Time.deltaTime));
            rb.GetComponent<StickToPlatform>().Velocity = rb.position - oldPosition;
            yield return new WaitForFixedUpdate();
        }
    }

    private void OnDisable()
    {
        rb.GetComponent<StickToPlatform>().Velocity = Vector3.zero;
    }
}
