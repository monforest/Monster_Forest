using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {

    private Rigidbody2D background;
    
	void Start ()
    {
        background = GetComponent<Rigidbody2D>();
        background.velocity = new Vector2(GameControl.gameControl.scrollSpeed, 0);
	}

	void Update ()
    {
	    if (GameControl.gameControl.gameOver)
        {
            background.velocity = Vector2.zero;
        }	
	}

}
