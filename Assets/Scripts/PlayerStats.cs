using System;
using UnityEngine;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour
{
    public int maxHealth;
    private float previousHealth;
    public int currentHealth;

    private float counter;
    public float maxCounter;

    GameObject c1, c2;

    public Image healthBar;

    public int damageFromEnemy;

    public bool isDead;

//    Animator animator;

    [HideInInspector] public int numberOfGold;
    [HideInInspector] public int numberOfCrystal;

    void Start()
    {
  //      animator = GetComponent<Animator>();
        c1 = GameObject.Find("Player/c1");
        c2 = GameObject.Find("Player/c2");
        isDead = false;
        currentHealth = maxHealth;
        previousHealth = maxHealth;
        numberOfGold = 0;
        numberOfCrystal = 0;
        counter = 0;
    }

    void Update()
    {

        if (counter < maxCounter)
        {
            counter += Time.deltaTime;
        }

        else
        {
            previousHealth = currentHealth;
            counter = 0;
        }

        //Animation for the healtbar
        healthBar.fillAmount = Mathf.Lerp(previousHealth / maxHealth, currentHealth / maxHealth, counter / maxCounter);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Gold")  //(other.gameObject.CompareTag("Player")
        {
            other.gameObject.SetActive(false);
            // Destroy(other.gameObject);

            numberOfGold++;
        }

        if (other.gameObject.tag == "Crystal")  //(other.gameObject.CompareTag("Player")
        {
            other.gameObject.SetActive(false);
            //            Destroy(other.gameObject);

            numberOfCrystal++;
        }

        if (other.gameObject.tag == "BulletEnemy1")
        {
            damageFromEnemy = 5;
            TakeDamage(damageFromEnemy);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "BulletEnemy2")
        {
            damageFromEnemy = 10;
            TakeDamage(damageFromEnemy);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "BulletEnemy3")
        {
            damageFromEnemy = 20;
            TakeDamage(damageFromEnemy);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "BulletEnemy4")
        {
            damageFromEnemy = 25;
            TakeDamage(damageFromEnemy);
            Destroy(other.gameObject);
        }

        
    }

    private void TakeDamage(int damage)
    {
        counter = 0;
        previousHealth = healthBar.fillAmount * maxHealth;

        currentHealth -= damage;
        if(currentHealth <= 0)
        {            
            Die();

            isDead = true;
        }
    }

    private void Die()
    {
        if (c1.activeSelf)
        {
            Debug.Log("c1 dead");
    //        animator.SetTrigger("Player1_dead");
            
        }
        else if (c2.activeSelf)
        {
            Debug.Log("c2 dead");
    //        animator.SetTrigger("Player2_dead");
        }

    }

}
