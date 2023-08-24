using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckForWin : MonoBehaviour
{
    // Start is called before the first frame update
    public bool redRight = false;
    public bool boldRight = false;
    private bool doOnce = false;
    public GameObject endScreen;
    public void EndGame()
    {
        
        if(doOnce == true)
        {
            return;
        }
        FindObjectOfType<CheckForWin>().GetComponent<Button>().interactable = false;

        if(redRight && boldRight)
        {
            SetTheText("You gitted good");
        }
        else
        {
            SetTheText("You died!");
        }
        Destroy(FindObjectOfType<PlayerMovement>().gameObject);
        doOnce = true;
    }

    private void SetTheText(string message)
    {
        endScreen.SetActive(true);
        endScreen.GetComponentInChildren<TextMeshProUGUI>().text = message;
    }
}
