using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    public float timeRemain = 39;
    public bool canMove = false;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (canMove)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
        
    }

    void FixedUpdate()
    {
        if (timeRemain > 0)
        {
            timeRemain -= Time.fixedDeltaTime;
        }
        else
        {
            canMove = true;
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        
    }
}
