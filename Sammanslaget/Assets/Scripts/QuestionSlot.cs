using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionSlot : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject codeBlock;
    [SerializeField] GameObject targetedText;

    private GameObject none;

    public enum RightAnswer {Bold, Red }
    [SerializeField] private RightAnswer facit;
    

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
            CheckForRightAnswer(false);
        }
        else if(codeBlock != null && player.state != PlayerMovement.InteractionState.holding) // if there is a block inside the thingy and the player is not holding
        {
            codeBlock.GetComponent<IInteractable>().Interact(player);
            codeBlock.GetComponent<BoxCollider2D>().enabled = true;

            if (targetedText == null)
            {
                codeBlock = null;
                return;
            }
            
            targetedText.GetComponent<TextChange>().ResetText();
            CheckForRightAnswer(true);
            codeBlock = null;
        }
     

    }
    private void CheckForRightAnswer(bool Removed)
    {
        CheckForWin winButton = FindObjectOfType<CheckForWin>();
        if(Removed)
        {
            if(facit == RightAnswer.Bold)
            {
                winButton.boldRight = false;
            }
            else
            {
                winButton.redRight = false;
            }
            return;
        }

        PickUp.WhatAmI answer = codeBlock.GetComponent<PickUp>().myType;
        
        if(answer == PickUp.WhatAmI.bold && facit == RightAnswer.Bold)
        {
            winButton.boldRight = true;
        }
        else if(answer == PickUp.WhatAmI.red && facit == RightAnswer.Red)
        {
            winButton.redRight = true;
        }
        else if(facit == RightAnswer.Bold)
        {
            winButton.boldRight = false;
        }
        else
        {
            winButton.redRight = false;
        }
    }
}
