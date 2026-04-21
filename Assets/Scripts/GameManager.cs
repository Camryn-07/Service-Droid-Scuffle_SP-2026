using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private InputAction pause;
    private bool isPaused;
    [SerializeField] private GameObject pauseScreen;

    private void Start()
    {
        pause = InputSystem.actions.FindAction("Menu");
        pause.performed += PausePerformed;
        isPaused = false;
    }

    private void PausePerformed(InputAction.CallbackContext obj)
    {
        isPaused = !isPaused;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    private void Update()
    {
        if (isPaused)
        { 
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    private void OnDestroy()
    {
        pause.performed -= PausePerformed;
    }
}
