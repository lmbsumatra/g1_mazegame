using UnityEngine;

public class Door : MonoBehaviour
{
    public Sprite openDoorSprite;
    public Sprite closedDoorSprite;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    private bool isDoorOpen = false;
    [SerializeField] private AudioClip openSound;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();

        if (spriteRenderer == null || boxCollider == null)
        {
            Debug.LogError("SpriteRenderer or BoxCollider2D not found on the GameObject with Door script.");
        }

        CloseDoor();
    }

    void Update()
    {
        if (KeyScoreManager.keyAmount >= 3 && !isDoorOpen)
        {
            OpenDoor();

        }
        else if (KeyScoreManager.keyAmount < 3 && isDoorOpen)
        {
            CloseDoor();
        }
    }

    private void OpenDoor()
    {
        spriteRenderer.sprite = openDoorSprite;
        boxCollider.enabled = false;
        isDoorOpen = true;
        SoundManager.instance.PlaySound(openSound);
    }

    private void CloseDoor()
    {
        spriteRenderer.sprite = closedDoorSprite;
        boxCollider.enabled = true;
        isDoorOpen = false;
    }
}
