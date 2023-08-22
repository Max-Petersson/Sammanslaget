using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    float vertical;
    float horizontal;
    public PickUp pickUp;

    float speed = 5;
    public IInteractable interactableObject;
    private enum MovementState { notInteracting, interacting }
    private MovementState state = MovementState.notInteracting;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }
    
    void GetInput()
    {
        vertical = Input.GetAxisRaw("Vertical");
        if (vertical != 0 && horizontal == 0)
        {
            transform.position += new Vector3(0, vertical) * speed * Time.deltaTime;
            //move up or down
        }

        horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal != 0 && vertical == 0)
        {
            transform.position += new Vector3(horizontal, 0) * speed * Time.deltaTime;
            //move left right
        }

        if (Input.GetButtonDown("Jump") && interactableObject != null && state == MovementState.notInteracting)
        {
            state= MovementState.interacting;
            interactableObject.Interact(this);
        }
        else if(Input.GetButtonDown("Jump") && state == MovementState.interacting)
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
}
