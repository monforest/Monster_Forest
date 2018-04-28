using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerPickup : InteractableItems
{
    public int healthModifier;

    PlayerStats playerStats;

    public bool isHealthModified;

   // Animator animator;

	void Start ()

    {
        isHealthModified = false;
     //   animator = GetComponent<Animator>();
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    void Update()
    {
        if (isInteractable)
        {
            Interact();
        }

        else
        {
            isHealthModified = false;
        }
    }

    public override void Interact()
    {
        //animator.SetTrigger
        base.Interact();
        if (!isHealthModified)
        {
            playerStats.ModifyHealth(healthModifier);
            isHealthModified = true;
        }  
    }
 
}
