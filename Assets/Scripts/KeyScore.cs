using UnityEngine;
using TMPro;

public class KeyScore : MonoBehaviour
{
    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

        if (text == null)
        {
            Debug.LogError("TextMeshProUGUI component not found on the GameObject with KeyScore script.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (text != null)
        {
            text.text = KeyScoreManager.keyAmount.ToString();
        }
    }
}