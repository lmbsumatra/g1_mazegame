using UnityEngine;

public class Chest : MonoBehaviour
{
    public Sprite open_chest; // The new sprite to be displayed on collision

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with the specific object you want to interact with
        if (collision.gameObject.CompareTag("Player"))
        {
            // Change the sprite of the object to the new sprite
            GetComponent<SpriteRenderer>().sprite = open_chest;

            // You can also perform other actions here if needed
        }
    }
}
