using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : Enemy
{

    public override void EnemyAction()
    {
        moveSpeed = 0;
        base.EnemyAction();

    }

    public override void EnemyAttack()
    {
        //??
        base.EnemyAttack();
    }
}
