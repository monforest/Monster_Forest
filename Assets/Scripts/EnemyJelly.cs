using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJelly : Enemy
{ 
    public Transform target;

    public override void EnemyAction()
    {
        float speed = moveSpeed;
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    public override void EnemyAttack()
    {
        base.EnemyAttack();
    }
}

