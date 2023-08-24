using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class TextChange : MonoBehaviour
{
    TextMeshProUGUI tmPro;
    private void Start()
    {
        tmPro = GetComponent<TextMeshProUGUI>();
        ResetText();
    }
    private void OnEnable()
    {
        PickUp.Message += ExpressChange;
    }
    private void OnDisable()
    {
        PickUp.Message -= ExpressChange;
    }

    void ExpressChange(PickUp.WhatAmI state, GameObject targetedText) //problem, everyone will try this, could encapsulate by sending which question this i asked by
    {
        if (targetedText != this.gameObject)
            return;

        switch (state)
        {
            case PickUp.WhatAmI.header:
                ResetText();
                tmPro.fontSize = 32;
                break;
            
            case PickUp.WhatAmI.bold: 
                ResetText(); 
                tmPro.fontStyle = FontStyles.Bold;
                break;
            
            case PickUp.WhatAmI.red:
                ResetText();
                tmPro.color = Color.red;
                break;
        }
        
    }
    
    public void ResetText()
    {
        tmPro.fontSize = 18;
        tmPro.fontStyle = FontStyles.Normal;
        tmPro.color = Color.black;
    }
}
