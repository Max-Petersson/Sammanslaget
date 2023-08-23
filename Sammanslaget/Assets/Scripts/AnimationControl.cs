using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    Animator anim;
    SpriteRenderer sprite;
    PlayerMovement pm;
    enum Direction {Up, Down, Left, Right, Idle}
    Direction myDir = Direction.Down;
    bool isIdle = true;
    [SerializeField] private List<Sprite> mySprites; 

    void Start()
    {
        anim = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
        sprite= GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

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
            
            anim.Play("New State");
            IdleSprite();
            return;
        }

        

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
            sprite.flipX = false;
        }
        else
        {
            sprite.flipX = true;
        }
    }
    private void IdleSprite()
    {
        switch (myDir)
        {
            case Direction.Up:
                sprite.sprite = mySprites[3];
                break;
            case Direction.Down:
                sprite.sprite = mySprites[2];
                break;
            case Direction.Left:
                sprite.sprite = mySprites[1];
                break;
            case Direction.Right:
                
                sprite.sprite = mySprites[1];
                break;
        }
    }
}
