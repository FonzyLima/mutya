using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    public float timeRemain;
    public static bool canMove = true;

    static bool leftMenu = false;

    // Crouching Mechanic
    public SpriteRenderer SpriteRenderer;
    public Sprite Standing;
    public Sprite Crouching; // Get Crouching Sprite

    // Tikbalang Conditions
    public bool isCrouching; // If player is crouching (For Tikbalang)
    public bool inGrass; // If player is in grass (For Tikbalang)
    public bool isMoving; // If Player is moving

    public BoxCollider2D Collider;

    public Vector2 StandingSize;
    public Vector2 CrouchingSize;

    public float velocityTest;

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

    void Start() {
        Collider = GetComponent<BoxCollider2D>();
        Collider.size = StandingSize;
        
        SpriteRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer.sprite = Standing;

        rb = GetComponent<Rigidbody2D>();

        StandingSize = Collider.size;
    }
    // Update is called once per frame
    void Update()
    {
        //check if player is moving
        if (movement.sqrMagnitude > 0){
            isMoving = true;
        }
        else{
            isMoving = false;
        }

        if (canMove)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);

            if (Input.GetKeyDown(KeyCode.LeftControl)){
                isCrouching = true;
                animator.SetBool("isCrouching", isCrouching);
                SpriteRenderer.sprite = Crouching;
                Collider.size = CrouchingSize;
                moveSpeed = 2;
            }

            if (Input.GetKeyUp(KeyCode.LeftControl)){
                isCrouching = false;
                animator.SetBool("isCrouching", isCrouching);
                SpriteRenderer.sprite = Standing;
                Collider.size = StandingSize;
                moveSpeed = 5;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Bush"){
            inGrass = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if(collision.tag == "Bush"){
            inGrass = false;
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
            leftMenu = true;
        }
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void setMove (bool move)
    {
        canMove = move;
    }
}
