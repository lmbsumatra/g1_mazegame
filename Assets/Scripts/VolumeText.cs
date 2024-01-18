using UnityEngine;
using UnityEngine.UI;

public class VolumeText : MonoBehaviour
{
    [SerializeField] private string volumeName;
    [SerializeField] private string textIntro; // Sound or Music
    private Text txt; // Change the variable type to Text

    private void Awake()
    {
        txt = GetComponent<Text>(); // Change the type to Text
        if (txt == null)
        {
            Debug.LogError("Text component not found on GameObject: " + gameObject.name);
        }
    }

    private void Update()
    {
        UpdateVolume();
    }

    private void UpdateVolume()
    {
        if (txt != null)
        {
            float volumeValue = PlayerPrefs.GetFloat(volumeName) * 100;
            txt.text = textIntro + volumeValue.ToString();
        }
        else
        {
            Debug.LogError("Text component is null. Check if the script is attached to a GameObject with a Text component.");
        }
    }
}
