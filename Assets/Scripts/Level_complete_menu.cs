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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
