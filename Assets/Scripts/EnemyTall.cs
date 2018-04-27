using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTall : Enemy
{

    public override void EnemyAction()
    {
        moveSpeed = 0;
        base.EnemyAction();
    }

    public override void EnemyAttack()
    {
        //fall down animation
        base.EnemyAttack();
    }
}
