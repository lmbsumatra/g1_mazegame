using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject torchPrefab;  // Reference to the Torch prefab

    void Start()
    {
        // Add a click listener to the button
        Button btn = GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(OnButtonClick);
        }
    }

    // Callback for the button click event
    void OnButtonClick()
    {
        // Instantiate the Torch prefab when the button is clicked
        GameObject torchInstance = Instantiate(torchPrefab, Vector3.zero, Quaternion.identity);

        // Find the TorchEffect script on the instantiated object
        TorchEffect torchEffect = torchInstance.GetComponent<TorchEffect>();

        // Call the OnButtonClick method in TorchEffect
        if (torchEffect != null)
        {
            Debug.Log("clicked");
            torchEffect.OnButtonClick();
        }
    }
}
