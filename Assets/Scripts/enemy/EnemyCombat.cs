using System.Collections;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public int maxHealth = 100;
    public float damageTimeout = 1f;
    private int currentHealth;
    private bool canTakeDamage = true;
    [SerializeField]
    private bool isAttacking = false;
    [SerializeField]
    private bool canAttack = true;
    [SerializeField]
    private float attackTimer = 0f;
    private Coroutine attacking;
 



    [SerializeField]private PlayerHealth playerHealth;
 
    [SerializeField]
    private float attackDamage = 5f;
    [SerializeField]
    private float attackRange = 0.65f;

    [SerializeField]
    private LayerMask playerLayer;


    void Start()
    {
        currentHealth = maxHealth;    
    }

    /* void Update()
     {
         Collider2D hitPlayer = Physics2D.OverlapCircle(transform.position, attackRange, playerLayer);

         if (hitPlayer != null)
         {
             // Debug.Log("we hit " + hitPlayer.name);
             hitPlayer.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
         }
     }
    */

    private void Update()
    {
        attackTimer -= 1 * Time.deltaTime;

        if (attackTimer < 0)
        {
            attackTimer = 0;
            canAttack = true;
        }
        if(attackTimer>0)
        {
            canAttack = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canAttack)
        {
            if (other.gameObject.tag == "Player" && GameManagement.manager.playerHealth > 0)
            {
                isAttacking = true;
                attacking = StartCoroutine(ContactAttack());

            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isAttacking=false;
            attackTimer = .5f;
        }
    }

    IEnumerator ContactAttack()
    {
        while (isAttacking)
        {
            playerHealth.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
            yield return new WaitForSeconds(1f);
            attackTimer = .1f;
        }

    }


    public void TakeDamage(int damage)
    {
        if (canTakeDamage)
        {
            currentHealth -= damage;

            Debug.Log("enemy health: " + currentHealth);

            if (currentHealth <= 0)
                Die();

            StartCoroutine(DamageTimer());
        }
    }

    IEnumerator DamageTimer()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(damageTimeout);
        canTakeDamage = true;
    }

    void Die()
    {
        Debug.Log("Enemy died!");
        canTakeDamage = false;
        // play death animation
        Destroy(gameObject);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
