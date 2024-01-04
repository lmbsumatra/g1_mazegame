using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using System.Collections;
using UnityEngine.Rendering.Universal;

public class TorchLight : MonoBehaviour
{
    public float radiusIncreaseAmount = 1.0f;
    public float duration = 5.0f;

    private bool isCoroutineRunning = false;

    private void OnMouseDown()
    {
        if (!isCoroutineRunning && !IsGamePaused())
        {
            StartCoroutine(IncreaseLightForDuration());
        }
    }

    private IEnumerator IncreaseLightForDuration()
    {
        isCoroutineRunning = true;

        // Assuming the light is attached to the player
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            Light2D playerLight = player.GetComponentInChildren<Light2D>();
            if (playerLight != null)
            {
                // Save the original radius
                float originalRadius = playerLight.pointLightOuterRadius;
                Debug.Log("Original Radius: " + originalRadius);

                // Increase the radius
                playerLight.pointLightOuterRadius += radiusIncreaseAmount;
                Debug.Log("Increased Radius: " + playerLight.pointLightOuterRadius);

                // Wait for the specified duration
                yield return new WaitForSeconds(duration);

                // Restore the original radius
                playerLight.pointLightOuterRadius = originalRadius;
                Debug.Log("Restored to Original Radius: " + originalRadius);
            }
            else
            {
                Debug.LogError("Light2D component not found on the player.");
            }
        }
        else
        {
            Debug.LogError("Player object not found.");
        }

        // Destroy the torch object after the coroutine has finished
        Destroy(gameObject);

        isCoroutineRunning = false;
    }

    private bool IsGamePaused()
    {
        // Check if the game is paused by accessing the Pause_menu script
        Pause_menu pauseMenu = FindObjectOfType<Pause_menu>();
        return pauseMenu != null && pauseMenu.IsPaused();
    }
}
