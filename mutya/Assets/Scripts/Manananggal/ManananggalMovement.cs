using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManananggalMovement : MonoBehaviour
{
    public float moveSpeed;

    public ManananggalDialogue dialogue;

    public Respawn respawn;

    public GameObject DeathScreen;
    public GameObject DeathDialogue;
    
    public Transform target;
    public Rigidbody2D rb;
    public Animator animator;
    public Vector3 dir;
    public float knockbackForce = 10000f;
    private int duration = 0;
    public AudioSource tiktikSFX;
    private float dist;

    Vector2 movement;
    public bool stop = false;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        StartCoroutine(playTiktik());
    }

    private IEnumerator playTiktik()
    {
        while(duration <= 120f){
            if(duration % 5 == 0){
                if(dist < 50f){
                    tiktikSFX.volume = 0.3f;
                    print("CLOSE");
                }
                else{
                    tiktikSFX.volume = 1f;
                    print("FAR");
                }
            tiktikSFX.Play();
            }
            duration++;
            yield return new WaitForSeconds(1f);
        }
        
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
        Vector3 offset = target.position - transform.position;
        dist = offset.sqrMagnitude;
        if(!stop)
            rb.MovePosition((Vector2)transform.position + ((Vector2)dir * moveSpeed * Time.deltaTime));
        
    }

    void OnFire() 
    {
        animator.SetTrigger("whipAttack");
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
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
            DeathScreen.SetActive(true);
            DeathDialogue.SetActive(true);
            dialogue.gameOverSet(true);
            respawn.setterDead(true);
        }
    }

    public void pauseManananggal(bool val)
    {
        stop = val;
    }
}
