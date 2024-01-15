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

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal input value
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
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
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
