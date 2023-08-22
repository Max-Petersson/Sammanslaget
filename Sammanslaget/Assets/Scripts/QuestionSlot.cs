using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionSlot : MonoBehaviour, IInteractable
{
    public void Interact(PlayerMovement player)
    {
        if(player.pickUp != null)
        {
            player.pickUp.gameObject.transform.SetParent(transform.GetChild(0), false);
            player.pickUp.gameObject.transform.localPosition = Vector3.zero;
        }
    }

    // Start is called before the first frame update
   
}
