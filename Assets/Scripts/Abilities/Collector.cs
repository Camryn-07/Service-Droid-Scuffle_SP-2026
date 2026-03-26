using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private MagnetPull Magnet;
    //[SerialeField] private (ability script name) (simple ability name)

    private void OnTriggerEnter(Collider triggerObject)
    {
        if (triggerObject.gameObject.CompareTag("Magnet"))
        {
            Magnet.enabled = true;
            Destroy(triggerObject.gameObject);
        }
        // Add a new "else if" and compare tag for each ability
        //else if (triggerObject.gameObject.CompareTag("ElectroTires"))
        //{
        //    Destroy(triggerObject.gameObject);
        //}
    }
}