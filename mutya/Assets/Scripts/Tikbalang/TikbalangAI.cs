using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TikbalangAI : MonoBehaviour
{
    //waypoints for tikbalang
    public Transform[] waypoints;

    //move speed of tikbalang
    [SerializeField]
    public float moveSpeed = 4f;

    //waypoint index
    public int wIdx = 0;

    public bool canMove = true;

    public GameObject player;
    private Transform playerPos;
    private Vector2 currentPos;
    private PlayerMovement playerMovement;
    public float distance;

    public TikbalangDialogue tDialogue;
    public GameObject deathDialogue;
    public GameObject deathScreen;
    public Respawn respawn;
    
    public Animator animator;

    public bool found;

    public AudioClip attackSFX;


    // Start is called before the first frame update
    private void Start()
    {
        //get starting waypoint
        transform.position = waypoints[wIdx].transform.position;

        //get player position
        playerPos = player.GetComponent<Transform>();
        currentPos = GetComponent<Transform>().position;

        //get Player Movement
        playerMovement = player.GetComponent<PlayerMovement>();
        found = false;

        
    }

    // Update is called once per frame
    private void Update()
    {
        if (canMove)
        {
            bool isNoisy = playerMovement.isMoving && (!playerMovement.isCrouching || playerMovement.inGrass);
            if (Vector2.Distance(transform.position, playerPos.position) < 1.5){ // If player is near tikbalang
                AudioSource.PlayClipAtPoint(attackSFX, transform.position, 0.1f);

                Vector3 dir = playerPos.position - transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                dir.Normalize();

                animator.SetFloat("Horizontal", dir.x);
                animator.SetFloat("Vertical", dir.y);
                animator.SetFloat("Speed", dir.sqrMagnitude);
                found = true;

                FollowPlayer();
                playerMovement.moveSpeed = 0;

                if (Vector2.Distance(transform.position, playerPos.position) == 0){
                    Death();
                }
            }
            else if(found || isNoisy && Vector2.Distance(transform.position, playerPos.position) < distance){// If player is noisy near tikbalang
                AudioSource.PlayClipAtPoint(attackSFX, transform.position, 0.1f);
                
                Vector3 dir = playerPos.position - transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                dir.Normalize();

                animator.SetFloat("Horizontal", dir.x);
                animator.SetFloat("Vertical", dir.y);
                animator.SetFloat("Speed", dir.sqrMagnitude);
                found = true;

                if (Vector2.Distance(transform.position, playerPos.position) == 0){
                    Death();
                }

                FollowPlayer();
                playerMovement.moveSpeed = 0;
            }
            else{ // If player is far away from tikbalang
                Move();
            }
        }
    }

    private void FollowPlayer(){
        moveSpeed = 7f;
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, moveSpeed * Time.deltaTime);
    }

    private void Move(){
        moveSpeed = 4f;
        if (wIdx < waypoints.Length){
            Vector3 dir = waypoints[wIdx].transform.position - playerPos.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            dir.Normalize();

            animator.SetFloat("Horizontal", dir.x);
            animator.SetFloat("Vertical", dir.y);
            animator.SetFloat("Speed", dir.sqrMagnitude);
            transform.position = Vector2.MoveTowards(transform.position, waypoints[wIdx].transform.position, moveSpeed * Time.deltaTime);
            if(transform.position == waypoints[wIdx].transform.position){
                wIdx += 1;
            }
        }
        else{
            wIdx = 0;
        }
    }

    public void setMove (bool val)
    {
        canMove = val;
    }

    private void Death(){
        if (tDialogue != null)
        {
            deathScreen.SetActive(true);
            deathDialogue.SetActive(true);
            tDialogue.gameOverSet(true);
            respawn.setterDead(true);
        }
    }
}
