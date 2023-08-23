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
    public enum InteractionState { notInteracting, interacting, holding }
    public InteractionState state = InteractionState.notInteracting;
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
        #region Movement
        vertical = Input.GetAxisRaw("Vertical");
        if (vertical != 0 && horizontal == 0)
        {
            transform.position += new Vector3(0, vertical) * speed * Time.deltaTime;
        }

        horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal != 0 && vertical == 0)
        {
            transform.position += new Vector3(horizontal, 0) * speed * Time.deltaTime;
        }
        #endregion

        if (Input.GetButtonDown("Jump") && interactableObject != null && state == InteractionState.notInteracting)
        {
            interactableObject.Interact(this);
        }
        else if(Input.GetButtonDown("Jump") && state == InteractionState.holding && interactableObject != null)
        {
            interactableObject.Interact(this);
        }
        else if(Input.GetButtonDown("Jump") && pickUp != null)
        {
            pickUp.gameObject.transform.parent = null;
            pickUp = null;
            state = InteractionState.notInteracting;
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
