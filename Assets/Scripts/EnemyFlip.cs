using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlip : MonoBehaviour {

    private Transform target;
    
    public float absLocalScaleX;

	void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        absLocalScaleX = Mathf.Abs(transform.localScale.x);
	}
	
	void Update () {

        float distance = target.position.x - transform.position.x;

        if (distance > 0)
        {
             transform.localScale = new Vector2(-absLocalScaleX, transform.localScale.y);  
        }

        if (distance < 0)
        {
            transform.localScale = new Vector2(absLocalScaleX, transform.localScale.y);
        }

    }
}


//SpriteRenderer[] sprites;

//sprites = GetComponentsInChildren<SpriteRenderer>();
//if(distance > 0)
//{
//    foreach (var sprite in sprites)
//    {
//        sprite.flipX = true;
//    }
//}

//else if(distance < 0)
//{
//    foreach (var sprite in sprites)
//    {
//        sprite.flipX = false;
//    }
//}

