using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Target: repeating background(background reposition), Same 2 background gameobjects needed, 
// when player(or camera) position reach to second background middle point, 
// first backgroun object moves to right side of the second background, 
// two background sprites reposition repeatedly endlessly!
// no hardcord !
// Background should have BoxCollider2D as a component mainly to measure horizontal length

// haaste? graphics, 


public class MidGround : RepeatingObject {

    //private float boxColliderHorizontalLength;
    //private BoxCollider2D boxcollider;
    private GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

	//void Start ()
 //   {
 //       boxcollider = GetComponent<BoxCollider2D>();
 //       boxColliderHorizontalLength = boxcollider.size.x;
	//}

	void Update ()
    {
        if (player.transform.position.x > transform.position.x + boxColliderHorizontalLength * 1.5f)
        {
            RepositionBackground();
        }
		
	}

    //private void RepositionBackground()
    //{
    //    Vector2 groundOffset = new Vector2(boxColliderHorizontalLength * 2f, 0);
    //    transform.position = (Vector2)transform.position + groundOffset;
    //}

}
