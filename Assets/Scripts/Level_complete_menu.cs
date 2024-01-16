using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_complete_menu : MonoBehaviour

{
    [SerializeField] GameObject level_complete;

    public void Home()
    {
        SceneManager.LoadScene("menu_main");
        Time.timeScale = 1;
    }

    public void Resume()
    {
        level_complete.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        // Assuming build index 1 is your game scene, adjust this according to your actual build settings
        int gameSceneIndex = 1;
        SceneManager.LoadScene(gameSceneIndex);
        KeyScoreManager.ResetKeyCount();

        // Ensure that Time.timeScale is set to 1
        Time.timeScale = 1f;
    }



}
