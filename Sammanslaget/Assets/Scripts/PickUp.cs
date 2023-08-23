using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour, IInteractable
{
    public static event Action <WhatAmI> Message; 
    public enum WhatAmI {bold, red }
    public WhatAmI myType;
    public void Interact(PlayerMovement player)
    {
        if (player.state == PlayerMovement.InteractionState.holding) // if you are holding something then dont interact with me
            return;

        gameObject.transform.SetParent(player.gameObject.transform.GetChild(0), false);
        gameObject.transform.localPosition = Vector3.zero;

        player.state= PlayerMovement.InteractionState.holding;
        player.pickUp = this;
    }
    public void ChangeText()
    {
        Message.Invoke(myType);
    }
}
