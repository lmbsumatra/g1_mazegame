using UnityEngine;

public class Chest : MonoBehaviour
{
    public Sprite openChestSprite; // The new sprite to be displayed on collision
    public Sprite closeChestSprite;
    public GameObject hintPopup; // Reference to the UI pop-up GameObject
    public float hintDuration = 5f;

    private bool isChestOpened = false;

    private void Start()
    {
        // Disable the hint pop-up initially
        hintPopup.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with the specific object you want to interact with
        if (collision.gameObject.CompareTag("Player") && !isChestOpened)
        {
            // Change the sprite of the object to the new sprite
            GetComponent<SpriteRenderer>().sprite = openChestSprite;

            // Show the hint pop-up
            hintPopup.SetActive(true);

            // Start the coroutine to hide the hint after a certain duration
            StartCoroutine(DisplayHint());

            // Mark the chest as opened
            isChestOpened = true;

            // You can also perform other actions here if needed
        }
    }

    private System.Collections.IEnumerator DisplayHint()
    {
        yield return new WaitForSeconds(hintDuration);

        // Hide the hint pop-up after the specified duration
        hintPopup.SetActive(false);
        CloseChest();
    }

    public void CloseHint()
    {
        // This method is called when the close button is clicked
        hintPopup.SetActive(false);
        CloseChest();
    }

    private void CloseChest()
    {
        // Set the sprite of the chest back to the closed state
        GetComponent<SpriteRenderer>().sprite = closeChestSprite;

        // Mark the chest as closed
        isChestOpened = false;
    }
}
