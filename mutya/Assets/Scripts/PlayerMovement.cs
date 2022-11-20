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

    // Crouching Mechanic
    public SpriteRenderer SpriteRenderer;
    public Sprite Standing;
    public Sprite Crouching; // Get Crouching Sprite

    public BoxCollider2D Collider;

    public Vector2 StandingSize;
    public Vector2 CrouchingSize;

    void Start(){
        Collider = GetComponent<BoxCollider2D>();
        Collider.size = StandingSize;
        
        SpriteRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer.sprite = Standing;

        StandingSize = Collider.size;
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

        if (Input.GetKeyDown(KeyCode.C)){
            SpriteRenderer.sprite = Crouching;
            Collider.size = CrouchingSize;
        }

        if (Input.GetKeyUp(KeyCode.C)){
            SpriteRenderer.sprite = Standing;
            Collider.size = StandingSize;
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