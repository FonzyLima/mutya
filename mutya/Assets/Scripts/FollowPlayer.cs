using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float moveSpeed;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    public float timeRemain;
    public bool canMove = false;

    static bool leftMenu = false;

    void Awake()
    {
        if (leftMenu)
        {
            timeRemain = 0;
        }
        else
        {
            timeRemain = 39;
        }
    }

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

    // Executes on a fixed time
    void FixedUpdate()
    {
        if (timeRemain > 0)
        {
            timeRemain -= Time.fixedDeltaTime;
        }
        else
        {
            leftMenu = true;
            canMove = true;
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
