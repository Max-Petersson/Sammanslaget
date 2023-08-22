using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionSlot : MonoBehaviour, IInteractable
{
    [SerializeField]GameObject codeBlock;
    public void Interact(PlayerMovement player)
    {
        if(player.pickUp != null && codeBlock == null)
        {
            GameObject currentlyInSlot = player.pickUp.gameObject;
            currentlyInSlot.transform.SetParent(transform.GetChild(0), false);
            currentlyInSlot.transform.localPosition = Vector3.zero;
            currentlyInSlot.GetComponent<PickUp>().ChangeText();
            codeBlock = currentlyInSlot;
           
            player.pickUp.GetComponent<BoxCollider2D>().enabled = false;
            player.pickUp = null;
        }
        else if(codeBlock!= null && player.pickUp == null) //
        {
            codeBlock.GetComponent<IInteractable>().Interact(player);
            codeBlock.GetComponent<BoxCollider2D>().enabled = true;
            codeBlock = null;
            
        }

    }

    // Start is called before the first frame update
   
}
