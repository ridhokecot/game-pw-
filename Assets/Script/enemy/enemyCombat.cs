using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCombat : MonoBehaviour
{
    public float speed;

    public float lineOfSite;
    public float attackArea;

    private Transform player;
    public Transform target;
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;
    public float attackRange = 2f;
    public int lightDamage = 10;
    public int heavyDamage = 20;
    public float cooldown;
    public float nextAttack;

    private int counter = 0;
    private int lightA;
    private int heavyA;

    public AudioClip attackSfx;
    public AudioClip blockSfx;
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lightA = lightDamage;
        heavyA = heavyDamage;
    }

    // Update is called once per frame
    void Update()
    {

        float distanceFromPlayer = Vector3.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSite && distanceFromPlayer > attackArea)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            spriteRenderer.flipX = direction.x > 0;
            transform.position += direction * speed * Time.deltaTime;
            animator.SetBool("Move", true);
            transform.position = Vector3.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
        else if (distanceFromPlayer <= attackArea && nextAttack < Time.time)
        {
            if (counter % 2 == 0)
            {
                source.clip = attackSfx;
                source.Play();
                counter += 1;
                lightAttack();
                nextAttack = Time.time + cooldown;
            }
            else
            {
                source.clip = attackSfx;
                source.Play();
                counter += 1;
                heavyAttack();
                nextAttack = Time.time + cooldown;
            }
            
        }
        else
        {
            animator.SetBool("Move", false);
        }

        if (Input.GetKeyDown(KeyCode.L) && Input.GetKey(KeyCode.L))
        {
            source.clip = blockSfx;
            source.Play();
            lightDamage = 0;
            heavyDamage = 0;
        }
        if (Input.GetKeyUp(KeyCode.L))
        {
            lightDamage = lightA;
            heavyDamage = heavyA;
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, attackArea);
    }

    void lightAttack()
    {
        // Play an light attack Animation
        animator.SetTrigger("lightAttack");
        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<playerHealth>().TakeDamage(lightDamage);
        }
    }

    void heavyAttack()
    {
        // Play an heavy attack Animation
        animator.SetTrigger("heavyAttack");
        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<playerHealth>().TakeDamage(heavyDamage);
        }
    }
}
