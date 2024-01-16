using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    private float horizontalInput;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 20;
    [SerializeField] private AudioClip attackSound;

    private Health playerHealth;  // Reference to the PlayerHealthScript

    void Start()
    {
        playerHealth = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal input value
        horizontalInput = Input.GetAxis("Horizontal");

        // Check if the player is alive before allowing the attack
        if (playerHealth.IsAlive() && Input.GetKeyUp(KeyCode.Space))
        {
            Attack();
        }
    }

    void Attack()
    {
        // Play the appropriate attack animation based on the player's direction
        if (horizontalInput < 0)
        {
            animator.SetTrigger("Attack_Left");
        }
        else if (horizontalInput > 0)
        {
            animator.SetTrigger("Attack_Right");
        }

        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Damage enemies
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Monster>().TakeDamage(attackDamage);
            // Apply damage to the enemy or perform other actions
        }
        SoundManager.instance.PlaySound(attackSound);
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
