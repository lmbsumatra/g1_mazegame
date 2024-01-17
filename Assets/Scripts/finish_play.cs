using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class finish_play : MonoBehaviour
{
    [SerializeField] GameObject Level_complete_window;
    [SerializeField] private AudioClip completerSound;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player") 
        {
            CompleteLevel();
            SoundManager.instance.PlaySound(completerSound);
        }
    }

    public void CompleteLevel()
    {
        Level_complete_window.SetActive(true);
        Time.timeScale = 0;
    }

}


