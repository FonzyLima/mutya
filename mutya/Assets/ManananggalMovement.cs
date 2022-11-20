using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManananggalMovement : MonoBehaviour
{
    public float moveSpeed;


    private Transform target;
    public Rigidbody2D rb;
    public Animator animator;
    public Vector3 dir;

    Vector2 movement;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // movement.x = Input.GetAxisRaw("Horizontal");
        // movement.y = Input.GetAxisRaw("Vertical");

        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

    }

    void FixedUpdate()
    {
        // rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition((Vector2)transform.position + ((Vector2)dir * moveSpeed * Time.deltaTime));
        
    }

    void OnFire() 
    {
        animator.SetTrigger("whipAttack");
    }
}
