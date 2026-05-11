using UnityEngine;
using System.Collections.Generic;

public class FloorActivation : MonoBehaviour
{
    [SerializeField] private Activator activator;
    [SerializeField] private List<GameObject> activatingObjects;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Crate"))
        {
            activatingObjects.Add(other.gameObject);
            if (activatingObjects.Count == 1)
            {
                activator.Activation();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Crate"))
        {
            activatingObjects.Remove(other.gameObject);
            if (activatingObjects.Count <= 0)
            {
                activator.Activation();
            }
        }
    }
}
