using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float moveSpeed;

    //public int maximumHealth;
    //private int currentHealth;

    //public int damageFromPlayer = 10;

    public GameObject bulletSpawner;  //child gameobject of the enemy, 
    private Transform target;
    public GameObject bullet; // prefab
    public float bulletForce;

    private Vector2 bulletDirection;

    public float timeBetweenAttacks = 4f;
    public float bulletDisappearTime = 2f;

    //    private Animator animator;

    bool isPlayerInRange;

    bool isPlayerDead;

    public float enemyReactionRange = 20f;
    public float enemyAttackRange = 8f;

    bool isCoroutineStarted = false;


	void Start () 
    {
  //      animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        isPlayerInRange = false;
        isPlayerDead = false;
	}
   
    
    void Update()
    {
      //  isEnemyDead = GetComponent<EnemyHealth>().isDead;
        isPlayerDead = GameControl.gameControl.isPlayerDead;
        EnemyMove();  
    }

    
    public void EnemyMove()
    {
        float distance = Mathf.Abs(target.position.x - transform.position.x);

        if (distance >= enemyReactionRange) //too far away, enemy do not react to player
        {
            //animator.SetTrigger("enemyIdle");
            return;
        }

        else if (distance > enemyAttackRange &&  distance < enemyReactionRange) //close enough to act
        {
            //animator.SetTrigger("enemyMove");
            isPlayerInRange = false;
            isCoroutineStarted = false;
            float speed = moveSpeed;
            Vector2 tempTarget = new Vector2(target.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, tempTarget, speed * Time.deltaTime);
          //  transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        else if (distance <= enemyAttackRange )     
        {
            transform.position = transform.position;
            //   animator.SetTrigger("enemyAttack");
            isPlayerInRange = true;

            if (!isCoroutineStarted)
            {
                StartCoroutine(ReadyToAttack(timeBetweenAttacks));
            }
        }
    }

    IEnumerator ReadyToAttack(float timeBetweenAttacks)
    {
        isCoroutineStarted = true;

        while (isPlayerInRange && !isPlayerDead )
        {
            EnemyAttack();
            yield return new WaitForSeconds(seconds: timeBetweenAttacks);
            Debug.Log("Attack made");
        }
    }

    public void EnemyAttack()
    {
        GameObject ammo = Instantiate(bullet, bulletSpawner.transform.position, Quaternion.identity);
        bulletDirection = target.position - bulletSpawner.transform.position;
        ammo.GetComponent<Rigidbody2D>().AddForce(bulletDirection * bulletForce * Time.deltaTime, ForceMode2D.Impulse);

        Destroy(ammo, t : bulletDisappearTime);
    }
}





//ammo.GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.localScale.x * bulletForce, 0), ForceMode2D.Impulse);
//Destroy(ammo, t: bulletDisappearTime);

//while (!isEnemyDead  && !isPlayerDead)  //until enemy or player died, keep attacking
//{
//Vector2 downward = new Vector2(0, -1);
////          Vector2 straight1 = transform.localScale.x * Vector2.right;
//Vector2 straight = new Vector2(transform.localScale.x, 0);
//if (target.position.y*2f < transform.position.y)
//{
//    bulletDirection = downward;
//}
//else bulletDirection = straight;

//           GameObject ammo = theBulletPooler.GetPooledObject();
//           ammo.transform.position = bulletSpawner.transform.position;
//           ammo.transform.rotation = Quaternion.identity;
//           ammo.SetActive(true);
//           ammo.GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.localScale.x * bulletForce, 0), ForceMode2D.Impulse);

///          yield return new WaitForSeconds(seconds: bulletDisappearTime);
//           ammo.SetActive(false); // or Destroy(ammo);   I will use Object Pooling for this bullet
//}



