using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering.Universal;

public class TorchEffect : MonoBehaviour
{
    public Light2D torchLight;  // Reference to the Light2D component
    public float increaseAmount = 1.0f;  // Amount to increase the light radius

    // Start is called before the first frame update
    void Start()
    {
        if (torchLight == null)
        {
            Debug.LogError("Torch Light is not assigned to the TorchEffect script.");
        }
    }

    // Method to increase the light radius
    public void IncreaseLightRadius()
    {
        if (torchLight != null)
        {
            torchLight.pointLightOuterRadius += increaseAmount;
        }
    }

    // Method to handle button click (called from ButtonController)
    public void OnButtonClick()
    {
        IncreaseLightRadius();
    }
}
