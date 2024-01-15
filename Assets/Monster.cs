using System.Collections;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth = 0;
    public Animator animator;

    // Flag to track if the monster is dead
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (!isDead)
        {
            Debug.Log("Enemy died");

            // Die Animation
            animator.SetBool("isDead", true);

            // Disable Collider
            GetComponent<Collider2D>().enabled = false;

            // Disable Monster script
            StartCoroutine(DisableMonsterWithDelay());

            // Set the flag to true to prevent further actions
            isDead = true;
        }
    }

    // Coroutine to disable the Monster script and hide the game object with a delay
    private IEnumerator DisableMonsterWithDelay()
    {
        // Wait for the death animation duration
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Hide the game object (set active to false)
        gameObject.SetActive(false);
    }
}
