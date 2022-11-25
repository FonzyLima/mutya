using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float moveSpeed;

    public Transform target;
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
        if (Vector2.Distance(transform.position, target.position) > 1)
        {
            rb.MovePosition((Vector2)transform.position + ((Vector2)dir * moveSpeed * Time.deltaTime));
        }
    }
}
