using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour, IInteractable
{

    public void Interact(PlayerMovement player)
    {
        gameObject.transform.SetParent(player.gameObject.transform.GetChild(0), false);
        gameObject.transform.localPosition = Vector3.zero;
        player.pickUp = this;
    }
}
