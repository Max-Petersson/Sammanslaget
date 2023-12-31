using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float vertical;
    float horizontal;
    public PickUp pickUp;
    private bool latestInputHorizontal;
    private bool inputFromAxes;

    public Vector3 dir;

    float speed = 5;
    public IInteractable interactableObject;
    public enum InteractionState { notInteracting, interacting, holding }
    public InteractionState state = InteractionState.notInteracting;
    

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Pickup();
    }

    void MovePlayer()
    {
        inputFromAxes = IsThereAxesInput();
        
        if (!inputFromAxes)
        {
            dir = Vector3.zero;
            return;
            
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            latestInputHorizontal = false;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            latestInputHorizontal = true;
        }

        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");

        switch (latestInputHorizontal)
        {
            case false:
                dir = new Vector3(0, vertical);
                break;

            case true:
                dir = new Vector3(horizontal, 0) ;
                break;
        }
        transform.position += dir * speed * Time.deltaTime;
    }
    
    void Pickup()
    {
        if (Input.GetButtonDown("Jump") && interactableObject != null)
        {
            interactableObject.Interact(this);
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IInteractable>() != null)
        {
            interactableObject = collision.gameObject.GetComponent<IInteractable>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IInteractable>() != null)
        {
            interactableObject = null;
        }
    }

    private bool IsThereAxesInput()
    {
        if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)
        {
            return false;
        }
        
        return true;
    }
    
    
    
}
