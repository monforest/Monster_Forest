using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPickup : InteractableItems
{ 
 //   public Item item;

    public int damageToPlayer;

    PlayerStats playerStats;

	// Use this for initialization
	void Start () {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    public override void Interact()
    {
        playerStats.TakeDamage(damageToPlayer);
        Destroy(gameObject);
    }
}
