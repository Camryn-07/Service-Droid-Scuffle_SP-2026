using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private AudioSource collectSound;
    [SerializeField] private MagnetPull Magnet;
    [SerializeField] private MonorailRide MR;
    //[SerialeField] private (ability script name) (simple ability name)

    private void OnTriggerEnter(Collider triggerObject)
    {
        if (triggerObject.gameObject.CompareTag("MagnetUpgrade"))
        {
            Magnet.enabled = true;
            Destroy(triggerObject.gameObject);
            collectSound.Play();
        }
        else if (triggerObject.gameObject.CompareTag("MonorailUpgrade"))
        {
            MR.enabled = true;
            Destroy(triggerObject.gameObject);
            collectSound.Play();
        }
        // Add a new "else if" and compare tag for each ability
        //else if (triggerObject.gameObject.CompareTag("ElectroTires"))
        //{
        //    Destroy(triggerObject.gameObject);
        //}
    }
}