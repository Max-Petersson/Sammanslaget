using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionSlot : MonoBehaviour, IInteractable
{
    [SerializeField]GameObject codeBlock;
    public void Interact(PlayerMovement player)
    {
        if (codeBlock != null && player.state == PlayerMovement.MovementState.holding) // if you are holding and there is something in the slot then return
            return;

        if(player.state == PlayerMovement.MovementState.holding && codeBlock == null) // if player is holding and there is no block in the slot
        {
            GameObject currentlyInSlot = player.pickUp.gameObject;
            currentlyInSlot.transform.SetParent(transform.GetChild(0), false);
            currentlyInSlot.transform.localPosition = Vector3.zero;
            currentlyInSlot.GetComponent<PickUp>().ChangeText();
            codeBlock = currentlyInSlot;
           
            player.pickUp.GetComponent<BoxCollider2D>().enabled = false; // turn of the picked up blocks colider
            player.state = PlayerMovement.MovementState.notInteracting;
            player.pickUp = null;
        }
        else if(codeBlock!= null && player.state != PlayerMovement.MovementState.holding) // if there is a block inside the thingy and the player is not holding
        {
            codeBlock.GetComponent<IInteractable>().Interact(player);
            codeBlock.GetComponent<BoxCollider2D>().enabled = true;
            codeBlock = null;
        }

    }

    // Start is called before the first frame update
   
}
