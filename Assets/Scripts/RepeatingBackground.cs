using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : RepeatingObject {

    //private BoxCollider2D groundCollider;
    //private float boxColliderHorizontalLength;

    //// Use this for initialization
    //void Start ()
    //{
    //       groundCollider = GetComponent<BoxCollider2D>();
    //       boxColliderHorizontalLength = groundCollider.size.x;
    //}

    public void Update () 
    {
		if(transform.position.x < - boxColliderHorizontalLength)
        {
            RepositionBackground();
        }
	}

    //void RepositionBackground()
    //{
    //    Vector2 groundOffset = new Vector2(boxColliderHorizontalLength * 2f, 0);
    //    transform.position = (Vector2)transform.position + groundOffset; 
    //}
}
