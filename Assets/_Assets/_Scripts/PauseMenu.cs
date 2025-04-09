using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("Pause Menu Settings")]
    [Tooltip("The UI panel representing the pause menu.")]
    public GameObject pauseMenuUI;

    [Header("Camera & Controls")]
    [Tooltip("The camera or player controller script that should be disabled when paused.")]
    public MonoBehaviour cameraController;

    [Header("Scene Settings")]
    [Tooltip("The name of the scene to load when returning to the menu.")]
    [SerializeField] private string menuSceneName = "MainMenu"; // Set the scene in the Inspector

    private bool isPaused = false;

    private void Update()
    {
        // Check if the M key is pressed to toggle the pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void Endgame()
    {
        Debug.Log("Game Over");
    }

    private void PauseGame()
    {
        pauseMenuUI.SetActive(true); // Show pause menu
        Time.timeScale = 0f;         // Pause the game time
        isPaused = true;

        // Unlock and show the cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // Disable camera or player control
        if (cameraController != null)
        {
            cameraController.enabled = false;
        }

        Debug.Log("Game paused.");
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false); // Hide pause menu
        Time.timeScale = 1f;          // Resume game time
        isPaused = false;

        // Lock and hide the cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // Enable camera or player control
        if (cameraController != null)
        {
            cameraController.enabled = true;
        }

        Debug.Log("Game resumed.");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Ensure time is running
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload current scene
        Debug.Log("Scene restarted.");
    }

    // Return to Menu with Scene Selection
    public void BackToMenu()
    {
        Time.timeScale = 1f; // Ensure the game is not paused when switching scenes
        SceneManager.LoadScene("Main Menu"); // Load the scene
        Debug.Log("Back to Menu"); 

    }
}
