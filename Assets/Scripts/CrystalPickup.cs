using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalPickup : InteractableItems
{
    public int earningPoint = 100;
    public float crystalDisappearTime;

    void Start()
    {
        
    }


    public override void Interact()
    {
        base.Interact();
        GameControl.gameControl.collectedCrystal++;
        GameControl.gameControl.score += earningPoint;
        Destroy(gameObject, t: crystalDisappearTime);
    }
}
