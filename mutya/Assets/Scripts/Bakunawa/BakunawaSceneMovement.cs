using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakunawaSceneMovement : MonoBehaviour
{
    public float moveSpeed;

    public Rigidbody2D rb;
    public Animator animator;
    public bool canMove = true;
    Vector2 movement;
    // Update is called once per frame
    void Update()
    {   
        //this is my movement for the player had to be diff i forgot why 
        if(!canMove){
            movement.x = 0;
            movement.y = 0;
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
        else{
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
        
        
        
    }
    void FixedUpdate()
    {
        if(canMove){
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    public void setMove (bool val)
    {
        canMove = val;
    }
}
