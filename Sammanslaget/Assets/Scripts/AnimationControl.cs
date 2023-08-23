using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    SpriteRenderer sprite;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        sprite= GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            anim.Play("WalkingLeftright");
        else
            anim.Play("New State");

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            sprite.flipX= false;
        }
        else
        {
            sprite.flipX= true;
        }
    }
}
