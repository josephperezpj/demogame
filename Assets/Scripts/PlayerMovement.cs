using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    Animator animator;

    public float runSpeed = 10.0f;
    public bool canMove;
    private bool _dead = false;



    void Start()
    {
        GameManagement.manager.onDeathTrigger += movementOff;
        body = GetComponent<Rigidbody2D>();
        canMove = true;

        animator = GetComponent<Animator>();
        animator.SetBool("isWalking", false);
        animator.SetFloat("animHorizontal", 1);
    }

    void Update()
    {

        if( !_dead){
        if(DialogueManager.GetInstance().dialogueIsPlaying){
            canMove = false;
        }
        else{
            canMove = true;
        }
        }

        if (canMove == true){
        
            horizontal = Input.GetAxisRaw("Horizontal"); 
            vertical = Input.GetAxisRaw("Vertical"); 

            if ( horizontal == 0 && vertical == 0 ){
                animator.SetBool("isWalking", false);
            }
            else if (horizontal != 0) {
                animator.SetBool("isWalking", true);
                animator.SetFloat("animHorizontal", horizontal);
                animator.SetFloat("animVertical", vertical);
            }
            else{
                animator.SetBool("isWalking", true);
                animator.SetFloat("animVertical", vertical); 
            }
        }

    }

    void FixedUpdate()
    {

        if (canMove)
        {
            if (horizontal != 0 && vertical != 0)
            {

                horizontal *= moveLimiter;
                vertical *= moveLimiter;
            }

            body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        }

        if (canMove == false)
        {
            body.velocity = new Vector2(0, 0);
        }
    }


    public void movementOff (){
        canMove = false;
        _dead = true;
    }

    private void OnDestroy (){
        GameManagement.manager.onDeathTrigger -= movementOff;
    }
}
