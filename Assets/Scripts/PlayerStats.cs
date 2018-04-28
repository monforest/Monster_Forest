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

    public int damageFromEnemy;

    public bool isDead;

//    Animator animator;

    [HideInInspector] public int numberOfCrystal;

    void Start()
    {
  //      animator = GetComponent<Animator>();
        c1 = GameObject.Find("Player/c1");
        c2 = GameObject.Find("Player/c2");
        isDead = false;
        currentHealth = maxHealth;
        previousHealth = maxHealth;

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
      //  healthBar.fillAmount = Mathf.Lerp(previousHealth / maxHealth, currentHealth / maxHealth, counter / maxCounter);

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Enemy")  //(other.gameObject.CompareTag("Player")
        {
            TakeDamage(damageFromEnemy);
        }
    }

    public void ModifyHealth(int healthModifier) 
    {
        currentHealth += healthModifier;
    }
    
    public void TakeDamage(int damage)
    {
        counter = 0;
   //     previousHealth = healthBar.fillAmount * maxHealth;

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
