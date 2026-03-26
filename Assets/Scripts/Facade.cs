using UnityEngine;

public class Facade : MonoBehaviour
{
    [SerializeField] private GameObject facade;

    void Update()
    {
        facade.transform.position = transform.position;
    }
}
