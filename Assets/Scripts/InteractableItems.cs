using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItems : MonoBehaviour {

    
    public bool isInteractable;

	
	void Update ()
    {

        if (isInteractable)
        {
            Interact();
        }
        
	}

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInteractable = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            isInteractable = false;
        }
    }

    public virtual void Interact()
    {
      
    }

    
}
