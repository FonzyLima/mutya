using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipHitbox : MonoBehaviour
{

    public Rigidbody2D player;
    public Rigidbody2D boss;
    public float knockbackForce = 5000f;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        print(other.tag);
        if(other.tag == "Enemy")
        {
            Vector2 direction = (Vector2) (player.position - boss.position).normalized;
            Vector2 knockback = direction * knockbackForce;
            print(knockback);
            boss.AddForce(knockback, ForceMode2D.Impulse);
        }
    }
}
