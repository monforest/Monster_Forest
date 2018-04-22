using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maximumHealth;
    private int currentHealth;

    public int damageFromPlayer;

    public bool isDead;

//    Animator animator;


    void Start () {

//        animator = GetComponent<Animator>();
        currentHealth = maximumHealth;      
    }
	
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            damageFromPlayer = 10;
            Destroy(other.gameObject);
            TakeDamage(damageFromPlayer);
        }

        if (other.gameObject.CompareTag("Weapon2"))
        {
            damageFromPlayer = 20;
            Destroy(other.gameObject);
            TakeDamage(damageFromPlayer);
        }
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            EnemyDie();
            isDead = true;
        }
    }

    private void EnemyDie()
    {
        //animator.SetTrigger("enemyDie");
        gameObject.SetActive(false); // or Destroy(gameObject);
    }
}
