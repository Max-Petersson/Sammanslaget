using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionSlot : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject codeBlock;
    [SerializeField] GameObject targetedText;

    public void Interact(PlayerMovement player)
    {
        if (codeBlock != null && player.state == PlayerMovement.InteractionState.holding) // if you are holding and there is something in the slot then return
            return;

        if(player.state == PlayerMovement.InteractionState.holding && codeBlock == null) // if player is holding and there is no block in the slot
        {
            GameObject currentlyInSlot = player.pickUp.gameObject;
            currentlyInSlot.transform.SetParent(transform.GetChild(0), false);
            currentlyInSlot.transform.localPosition = Vector3.zero;
            
            currentlyInSlot.GetComponent<PickUp>().ChangeText(targetedText); // which text should be changed
            codeBlock = currentlyInSlot; //Add the picked up gameobject 
           
            player.pickUp.GetComponent<BoxCollider2D>().enabled = false; // turn off the picked up blocks collider
            player.state = PlayerMovement.InteractionState.notInteracting;
            player.pickUp = null;
        }
        else if(codeBlock != null && player.state != PlayerMovement.InteractionState.holding) // if there is a block inside the thingy and the player is not holding
        {
            codeBlock.GetComponent<IInteractable>().Interact(player);
            codeBlock.GetComponent<BoxCollider2D>().enabled = true;
            targetedText.GetComponent<TextChange>().ResetText();
            codeBlock = null;
        }
     

    }
}
