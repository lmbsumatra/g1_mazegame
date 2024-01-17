using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private float numberOfFlashes;
    private SpriteRenderer spriteRend;

    [Header("Death Sound")]
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip hurtSound;

    [Header("Game Over")]
    [SerializeField] private GameObject gameOverWindow;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float _damage)
    {
        if (!dead) // Check if the character is alive
        {
            currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

            if (currentHealth > 0)
            {
                anim.SetTrigger("hurt");
                StartCoroutine(Invulnerability());
                SoundManager.instance.PlaySound(hurtSound);
            }
            else
            {
                Die();
            }
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    public bool IsAlive()
    {
        return !dead;
    }

    private void Die()
    {
        if (!dead)
        {
            anim.SetTrigger("die");
            GetComponent<Player>().enabled = false;
            dead = true;
            SoundManager.instance.PlaySound(deathSound);

            // Add a delay before displaying game over window
            StartCoroutine(DelayedGameOver());
        }
    }

    private IEnumerator DelayedGameOver()
    {
        yield return new WaitForSeconds(3f); // Adjust the delay duration as needed

        // Display game over window
        if (gameOverWindow != null)
        {
            gameOverWindow.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);

        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }

        Physics2D.IgnoreLayerCollision(10, 11, false);
    }
}
