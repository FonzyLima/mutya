using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManananggalMovement : MonoBehaviour
{
    public float moveSpeed;


    public Transform target;
    public Rigidbody2D rb;
    public Animator animator;
    public Vector3 dir;
    public float knockbackForce = 10000f;

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

    private void OnTriggerEnter2D(Collider2D other) 
    {
        print(other.tag);
        if(other.tag == "Weapon")
        {
            Vector2 direction = (Vector2) (dir).normalized;
            Vector2 knockback = direction * knockbackForce * -1;
            print(knockback);
            rb.AddForce(knockback);
        }
        else if(other.tag == "Player")
        {
            print("Game Over");
        }
    }
}
