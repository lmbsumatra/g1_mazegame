using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class menu_main : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
        KeyScoreManager.ResetKeyCount();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
