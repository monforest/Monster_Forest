using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float moveSpeed;

    private Transform target;

    public float timeBetweenAttacks = 4f;
	
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
        isPlayerDead = GameControl.gameControl.isPlayerDead;
        EnemyMove();  
    }

    
    public void EnemyMove()
    {
        float distance = Mathf.Abs(target.position.x - transform.position.x);

        if (distance >= enemyReactionRange) 
        {
            //animator.SetTrigger("enemyIdle");
            return;
        }

        else if (distance > enemyAttackRange &&  distance < enemyReactionRange)
        {
            //animator.SetTrigger("enemyMove");
            isPlayerInRange = false;
            isCoroutineStarted = false;
            EnemyAction();
           
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
        }
    }

    public virtual void EnemyAction()
    {
       
    }

    public virtual void EnemyAttack()
    {
        // animator.SetTrigger(" " )
    }
}





