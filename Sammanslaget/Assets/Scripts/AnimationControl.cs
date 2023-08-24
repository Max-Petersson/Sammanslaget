using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    Animator anim;
    SpriteRenderer spriteRender;
    PlayerMovement pm;
    enum Direction {Up, Down, Left, Right, Idle}
    Direction myDir = Direction.Down;
    bool isIdle = false;
    public List<Sprite> mySprites = new List<Sprite>(); 

    void Start()
    {
        anim = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
        spriteRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        isIdle = false;

        if (pm.dir.y > 0)
        {
            myDir = Direction.Up;
        }
        else if(pm.dir.y < 0) 
        {
            myDir = Direction.Down;
        }
        else if(pm.dir.x < 0) 
        {
            myDir = Direction.Left;
        }
        else if(pm.dir.x > 0)
        {
            myDir = Direction.Right;
        }
        else
        {
            isIdle = true;
        }

        if (isIdle == true)
            return;
        switch (myDir)
        {
            case Direction.Up:
                anim.Play("Up");
                break;
            case Direction.Down:
                anim.Play("Down");
                break;
            case Direction.Left:
                anim.Play("WalkingLeftright");
                break;
            case Direction.Right:
                anim.Play("WalkingLeftright");
                break;
        }

        if (myDir == Direction.Left)
        {
            spriteRender.flipX = false;
        }
        else
        {
            spriteRender.flipX = true;
        }
    }
    private void LateUpdate()
    {
        if (isIdle == true)
        {
            anim.Play("New State");
            IdleSprite();
            return;
        }
       
    }
    private void IdleSprite()
    {
        switch (myDir)
        {
            case Direction.Up:
                spriteRender.sprite = mySprites[3];
                break;
            case Direction.Down:
                spriteRender.sprite = mySprites[2];
                break;
            case Direction.Left:
                spriteRender.sprite = mySprites[1];
                break;
            case Direction.Right:
                spriteRender.sprite = mySprites[1];
                break;
        }
    }
}
