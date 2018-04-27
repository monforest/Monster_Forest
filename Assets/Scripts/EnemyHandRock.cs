using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandRock : Enemy
{

    public Transform target;

    public GameObject bulletSpawner;  //child gameobject of the enemy, 
    public GameObject bullet; // prefab
    public float bulletForce;
    private Vector2 bulletDirection;

    public float bulletDisappearTime = 2f;


    public override void EnemyAction()
    {
        float speed = moveSpeed;
        Vector2 tempTarget = new Vector2(target.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, tempTarget, speed * Time.deltaTime);
    }

    public override void EnemyAttack()
    {
        GameObject ammo = Instantiate(bullet, bulletSpawner.transform.position, Quaternion.identity);
        bulletDirection = target.position - bulletSpawner.transform.position;
        ammo.GetComponent<Rigidbody2D>().AddForce(bulletDirection * bulletForce * Time.deltaTime, ForceMode2D.Impulse);

        Destroy(ammo, t: bulletDisappearTime);
    }
}
