using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalPickup : InteractableItems
{
    void Update()
    {

      //  transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);

        if (GameControl.gameControl.gameOver)
        {
            gameObject.SetActive(true);
        }

        if (isInteractable)
        {
            Interact();
        }
    }

    public override void Interact()
    {
        //base.Interact();
        GameControl.gameControl.crystalPoint++;
        gameObject.SetActive(false);
    }
}
