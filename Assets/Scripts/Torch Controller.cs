using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using System.Collections;
using UnityEngine.Rendering.Universal;

public class TorchController : MonoBehaviour
{
    public Light2D torchLight;
    public float minIntensity = 0.8f;
    public float maxIntensity = 1.0f;
    public float minFalloff = 1.5f;
    public float maxFalloff = 2.0f;
    public float flickerSpeed = 2.0f;

    private float perlinOffset;

    void Start()
    {
        perlinOffset = Random.value * 10f; // Random offset for Perlin noise
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            float noise = Mathf.PerlinNoise(perlinOffset, Time.time * flickerSpeed);

            float intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
            float falloff = Mathf.Lerp(minFalloff, maxFalloff, noise);

            torchLight.intensity = intensity;
            torchLight.pointLightOuterRadius = falloff;

            yield return null;
        }
    }
}
