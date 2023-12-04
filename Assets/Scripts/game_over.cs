using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class game_over : MonoBehaviour
{
    
    [SerializeField] GameObject Game_over_window;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player") 
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Game_over_window.SetActive(true);
        Time.timeScale = 0;

    }


}


