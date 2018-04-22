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
            Debug.Log("Enemy Got Damaged from Player");
            Destroy(other.gameObject);

            currentHealth -= damageFromPlayer;

            if (currentHealth <= 0)
            {
                isDead = true;
                EnemyDie();
            }
        }
    }

    private void EnemyDie()
    {
        //animator.SetTrigger("enemyDie");
        gameObject.SetActive(false); // or Destroy(gameObject);
    }
}
