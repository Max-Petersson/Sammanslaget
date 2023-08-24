using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForWin : MonoBehaviour
{
    // Start is called before the first frame update
    public bool redRight = false;
    public bool boldRight = false;
    public void EndGame()
    {
        if(redRight && boldRight)
        {
            Debug.Log("you Win");
        }
        else
        {
            Debug.Log("You Loose");
            //lose
        }
    }
}
