using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    private void OnTriggerEnter(Collider collidingObject)
    {
        if (collidingObject.gameObject.CompareTag("Player"))
        {
            //loads next scene from the Build Profiles scene list
            Debug.Log("You Win!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}