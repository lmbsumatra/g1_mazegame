using System.Collections;
using UnityEngine;
using TMPro;

public class DialogUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogObject testDialogue;
    [SerializeField] private GameObject dialogueBox;

    private ResponseHandler responseHandler;
    private TypewriterEffect typewriterEffect;

    private void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        responseHandler = GetComponent<ResponseHandler>();

        CloseDialogueBox();
        ShowDialogue(testDialogue);
    }

    public void ShowDialogue(DialogObject dialogueObject)
    {
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue(DialogObject dialogueObject)
    {
        for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];
            yield return typewriterEffect.Run(dialogue, textLabel);

            // Fixed typo: Use '==' instead of '=' for comparison
            if (i == dialogueObject.Dialogue.Length - 1 && dialogueObject.HasResponses)
                break;

            // Wait for mouse click before proceeding to the next dialogue
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        }

        if (dialogueObject.HasResponses)
        {
            responseHandler.ShowResponses(dialogueObject.Responses);
        }
        else
        {
            CloseDialogueBox();
        }
    }

    private void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
