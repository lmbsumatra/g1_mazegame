using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    [SerializeField] private float typewriteSpeed = 30f;

    // Changed the Run method to take two parameters: textToType and textLabel
    public Coroutine Run(string textToType, TMP_Text textLabel)
    {
        // Call StartCoroutine with the correct parameters
       return StartCoroutine(TypeText(textToType, textLabel));
    }

    // Modified the TypeText method signature to match the Run method
    private IEnumerator TypeText(string textToType, TMP_Text textLabel)
    {
        textLabel.text = string.Empty;

        float t = 0;
        int charIndex = 0;

        while (charIndex < textToType.Length)
        {
            t += Time.deltaTime * typewriteSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            textLabel.text = textToType.Substring(0, charIndex);

            yield return null;
        }
        textLabel.text = textToType;
    }
}
