using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer mainMixer;
    public TMP_Dropdown resolutionDropdown; // Change the type to TMP_Dropdown

    private Resolution[] resolutions;

    private const string VolumeKey = "AudioVolume";
    private const string FullscreenKey = "IsFullscreen";
    private const string QualityKey = "QualityLevel";

    private void Start()
    {
        try
        {
            resolutions = Screen.resolutions;
            PopulateResolutionDropdown();
            // Load the saved settings when the game starts
            if (PlayerPrefs.HasKey(VolumeKey))
            {
                float savedVolume = PlayerPrefs.GetFloat(VolumeKey);
                SetVolume(savedVolume);
            }

            if (PlayerPrefs.HasKey(FullscreenKey))
            {
                bool savedFullscreen = PlayerPrefs.GetInt(FullscreenKey) == 1;
                SetFullscreen(savedFullscreen);
            }

            if (PlayerPrefs.HasKey(QualityKey))
            {
                int savedQuality = PlayerPrefs.GetInt(QualityKey);
                SetQuality(savedQuality);
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error getting screen resolutions: " + e.Message);
        }
    }

    private void PopulateResolutionDropdown()
    {
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        // Set the default value of the resolution dropdown to match the current screen resolution
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        // Check if the volume setting has changed
        if (volume != PlayerPrefs.GetFloat(VolumeKey))
        {
            mainMixer.SetFloat("volume", volume);

            // Save the volume setting
            PlayerPrefs.SetFloat(VolumeKey, volume);
            PlayerPrefs.Save();
        }
    }

    public void SetFullscreen(bool isFullscreen)
    {
        // Check if the fullscreen setting has changed
        if (isFullscreen != Screen.fullScreen)
        {
            Screen.fullScreen = isFullscreen;

            // Save the fullscreen setting
            PlayerPrefs.SetInt(FullscreenKey, isFullscreen ? 1 : 0);
            PlayerPrefs.Save();
        }
    }

    public void SetQuality(int qualityIndex)
    {
        // Check if the quality setting has changed
        if (qualityIndex != QualitySettings.GetQualityLevel())
        {
            QualitySettings.SetQualityLevel(qualityIndex);

            // Save the quality setting
            PlayerPrefs.SetInt(QualityKey, qualityIndex);
            PlayerPrefs.Save();
        }
    }
}
