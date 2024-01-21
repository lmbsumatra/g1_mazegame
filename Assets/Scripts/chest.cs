using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Chest : MonoBehaviour
{
    public Sprite openChestSprite; // The new sprite to be displayed on collision
    public Sprite closeChestSprite;
    public GameObject hintPopup; // Reference to the UI pop-up GameObject

    public TMP_InputField passwordInputField; // Reference to the TextMeshPro input field
    public GameObject errorPopup;
    public GameObject correctPopup;

    [SerializeField] private AudioClip chestSound;

    [SerializeField]
    private string chestPassword; // Unique password for each chest

    public Button okButton; // Reference to the Ok button
    public Button backButton; // Reference to the Back button

    public AudioSource correctAudioSource; // sound effect
    public AudioSource incorrectAudioSource;

    private bool isChestOpened = false;

    private Player player; // Reference to the Player script

    private void Start()
    {
        // Disable the hint pop-up initially
        hintPopup.SetActive(false);
        errorPopup.SetActive(false);
        correctPopup.SetActive(false);


        okButton.onClick.AddListener(SubmitPassword);
        backButton.onClick.AddListener(CloseChestWithoutOpening);

        player = FindObjectOfType<Player>(); // Find the Player script in the scene
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with the specific object you want to interact with
        if (collision.gameObject.CompareTag("Player") && !isChestOpened)
        {
            // Change the sprite of the object to the new sprite
            GetComponent<SpriteRenderer>().sprite = openChestSprite;

            if (!isChestOpened)
            {
                player.SetCanMove(false); // Stop player movement
                hintPopup.SetActive(true);// Show the hint pop-up
                isChestOpened = true; // Mark the chest as opened
                StartCoroutine(WaitForInput()); // Wait for user input
            }
        }
        SoundManager.instance.PlaySound(chestSound);
    }

    private IEnumerator WaitForInput()
    {
        while (true)
        {
            // Check if the chest is still closed
            if (!isChestOpened)
            {
                // Check if the user has provided input
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    // Hide the hint pop-up
                    hintPopup.SetActive(false);

                    // Process the password
                    if (CheckPassword())
                    {
                        OpenChest();
                    }
                    else
                    {
                        errorPopup.SetActive(true);
                        yield return new WaitForSeconds(2f); // Adjust the duration as needed
                        errorPopup.SetActive(false);
                        CloseChest();
                    }

                    // Exit the loop
                    break;
                }
            }

            yield return null;
        }
    }

    private void SubmitPassword()
    {
        // Hide the hint pop-up
        hintPopup.SetActive(false);

        // Process the password
        if (CheckPassword())
        {
            OpenChest();
        }
        else
        {
            errorPopup.SetActive(true);
            // Play the audio clip for incorrect password
            if (incorrectAudioSource != null && incorrectAudioSource.clip != null)
            {
                incorrectAudioSource.Play();
            }
            StartCoroutine(HideErrorPopup());
        }
    }

    // Add a method to set the password for each chest
    public void SetPassword(string newPassword)
    {
        chestPassword = newPassword;
    }
    private void CloseChestWithoutOpening()
    {
        // Hide the hint pop-up
        hintPopup.SetActive(false);

        // Set the sprite of the chest back to the closed state
        GetComponent<SpriteRenderer>().sprite = closeChestSprite;

        // Mark the chest as closed
        isChestOpened = false;

        player.SetCanMove(true);
    }

    private void RetryAfterIncorrect()
    {
        errorPopup.SetActive(false);
        ResetChestState();
    }

    private void ResetChestState()
    {
        // Clear the input field
        passwordInputField.text = "";

        // Set the sprite of the chest back to the closed state
        GetComponent<SpriteRenderer>().sprite = closeChestSprite;

        // Mark the chest as closed
        isChestOpened = false;

        // Show the hint pop-up again
        hintPopup.SetActive(true);
    }

    private IEnumerator HideErrorPopup()
    {
        yield return new WaitForSeconds(2f); // Adjust the duration as needed
        errorPopup.SetActive(false);
        // Reset the chest state after hiding the error popup
        ResetChestState();
    }

    private IEnumerator HideCorrectPopup()
    {
        yield return new WaitForSeconds(2f); // Adjust the duration as needed
        correctPopup.SetActive(false);
    }

    private bool CheckPassword()
    {
        return passwordInputField.text.ToLower() == chestPassword.ToLower(); //Set the letter to small just incase user input capital
    }

    private void OpenChest()
    {
        KeyScoreManager keyScoreManager = FindObjectOfType<KeyScoreManager>();
        if (keyScoreManager != null)
        {
            keyScoreManager.IncrementKeyCount(); // add key 
        }

        passwordInputField.text = "";
        GetComponent<SpriteRenderer>().sprite = openChestSprite;
        correctPopup.SetActive(true);

        if (correctAudioSource != null && correctAudioSource.clip != null) //audio for correct guess
        {
            correctAudioSource.Play();
        }

        StartCoroutine(HideCorrectPopup());
        isChestOpened = true; // Mark the chest as opened
        player.SetCanMove(true);
    }

    private void CloseChest()
    {
        // Set the sprite of the chest back to the closed state
        GetComponent<SpriteRenderer>().sprite = closeChestSprite;

        // Mark the chest as closed
        isChestOpened = false;
        player.SetCanMove(true);
    }

}