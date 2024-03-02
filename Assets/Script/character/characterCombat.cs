using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterCombat : MonoBehaviour
{
    public Animator animator;

    public float attackRange = 0.3f;
    public int lightDamage = 10;
    public int heavyDamage = 20;

    public Transform attackPoint;
    public LayerMask enemyLayers;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    private int lightA;
    private int heavyA;

    public AudioClip attackSfx;
    public AudioClip blockSfx;
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        lightA = lightDamage;
        heavyA = heavyDamage;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextAttackTime)
        {  
            if (Input.GetKeyDown(KeyCode.J))
            {
                source.clip = attackSfx;
                source.Play();
                lightAttack();
                nextAttackTime = Time.time + 1f / attackRate;
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                source.clip = attackSfx;
                source.Play();
                heavyAttack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
        blocking();
        if (Input.GetKeyDown(KeyCode.L) && Input.GetKey(KeyCode.L))
        {
            source.clip = blockSfx;
            source.Play();
            heavyDamage = 0;
            lightDamage = 0;
        }
        if (Input.GetKeyUp(KeyCode.L))
        {
            lightDamage = lightA;
            heavyDamage = heavyA;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void lightAttack()
    {
        // Play an light attack Animation
        animator.SetTrigger("lightAttack");
        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<enemyHealth>().TakeDamage(lightDamage);
        }
    }

    void heavyAttack()
    {
        animator.SetTrigger("heavyAttack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<enemyHealth>().TakeDamage(heavyDamage);
        }
    }

    void blocking()
    {
        if (Input.GetKeyDown(KeyCode.L) && Input.GetKey(KeyCode.L))
        {
            animator.SetBool("block", true);
        }
        if (Input.GetKeyUp(KeyCode.L))
        {
            animator.SetBool("block", false);
        }
    }
}
