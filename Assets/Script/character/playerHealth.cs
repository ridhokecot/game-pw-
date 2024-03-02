using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class playerHealth : MonoBehaviour
{
    public Animator animator;

    [SerializeField]private int health = 200;
    private int MAX_HEALTH = 200;

    public healthBar healthBar;
    public int blocking = 0;

    public AudioClip sfx;
    public AudioSource source;

    public void SetHealth(int maxHealth, int health)
    {
        this.MAX_HEALTH = maxHealth;
        this.health = health;
    }

    private IEnumerator VisualIndicator(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    // Start is called before the first frame update
    void Start()
    {
        health = MAX_HEALTH;
        healthBar.SetMaxHealth(MAX_HEALTH);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(int damage)
    {
        StartCoroutine(VisualIndicator(Color.red));
        this.health -= damage;

        source.clip = sfx;
        source.Play();

        healthBar.SetHealth(health);

        if (health <= 0)
        {
            Die();
            SceneManager.LoadScene("defeatScene");
        }
    }

    void Die()
    {
        Debug.Log("Die");
        animator.SetTrigger("death");

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
