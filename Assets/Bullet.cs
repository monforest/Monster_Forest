using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


    public float bulletForce;
    private Vector2 bulletDirection;

    private GameObject target;  // where bullet goes
   // private Transform origin;  // spawning point

    private Rigidbody2D rb2d;

    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        
        rb2d = GetComponent<Rigidbody2D>();
        bulletDirection = target.transform.position - transform.position;

        //  transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    public void BulletAction(Vector2 direction)
    {
        
        direction = bulletDirection;
       // bulletDirection = target.transform.position - origin.transform.position;
        rb2d.AddForce(direction * bulletForce * Time.deltaTime, ForceMode2D.Impulse);
    }

    
	
}
