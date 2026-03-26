using UnityEngine;

public class Activator : MonoBehaviour
{
    [SerializeField] private bool activated;
    [SerializeField] private GameObject[] activatedObjects;
    private int currentIndex;

    public bool Activated { get => activated; set => activated = value; }

    private void Start()
    {
        currentIndex = 0;
    }
    void Update()
    {
        if (activated)
        {
            if (currentIndex < activatedObjects.Length)
            {
                activatedObjects[currentIndex].SetActive(!activatedObjects[currentIndex].activeSelf);
                currentIndex++;
            }
            else
            {
                activated = false;
                currentIndex = 0;
            }
        }
    }
    public void Activation()
    {
        activated = true;
    }
}
