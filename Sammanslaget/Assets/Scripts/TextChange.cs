using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextChange : MonoBehaviour
{
    TextMeshProUGUI tmPro;
    private void Start()
    {
        tmPro = GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        PickUp.Message += ExpressChange;
    }
    private void OnDisable()
    {
        PickUp.Message -= ExpressChange;
    }
    void ExpressChange(PickUp.WhatAmI state)
    {
        if(state == PickUp.WhatAmI.bold)
        {
            ResetText();
            tmPro.fontStyle = FontStyles.Bold;
        }
        else if(state == PickUp.WhatAmI.red)
        {
            ResetText();
            tmPro.color = Color.red;
        }
    }
    void ResetText()
    {
        tmPro.fontStyle = FontStyles.Normal;
        tmPro.color = Color.black;
    }
}
