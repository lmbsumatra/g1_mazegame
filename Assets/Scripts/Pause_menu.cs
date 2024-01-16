using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_menu : MonoBehaviour
{
    [SerializeField] GameObject pause_window;
    private bool isPaused = false; // New variable to track pause state

    public void Pause()
    {
        pause_window.SetActive(true);
        Time.timeScale = 0;
        isPaused = true; // Set the pause state to true
    }

    public void Home()
    {
        SceneManager.LoadScene("menu_main");
        Time.timeScale = 1;
        isPaused = false; // Set the pause state to false
    }

    public void Resume()
    {
        pause_window.SetActive(false);
        Time.timeScale = 1;
        isPaused = false; // Set the pause state to false
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        KeyScoreManager.ResetKeyCount();

        // Ensure that Time.timeScale is set to 1
        Time.timeScale = 1f;
    }

    // New method to check if the game is paused
    public bool IsPaused()
    {
        return isPaused;
    }
}
