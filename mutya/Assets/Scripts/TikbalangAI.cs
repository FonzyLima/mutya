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
    private int wIdx = 0;

    public GameObject player;
    private Transform playerPos;
    private Vector2 currentPos;
    private PlayerMovement playerMovement;
    public float distance;


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
    }

    // Update is called once per frame
    private void Update()
    {
        if(!playerMovement.isCrouching && Vector2.Distance( transform.position, playerPos.position) < distance){
            FollowPlayer();
        }
        else
            Move();
    }

    private void FollowPlayer(){
        moveSpeed = 7f;
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, moveSpeed * Time.deltaTime);
    }

    private void Move(){
        moveSpeed = 4f;
        if (wIdx <= waypoints.Length - 1){
            transform.position = Vector2.MoveTowards(transform.position, waypoints[wIdx].transform.position, moveSpeed * Time.deltaTime);
            if(transform.position == waypoints[wIdx].transform.position){
                wIdx += 1;
            }
        }
        else{
            wIdx = 0;
        }
    }
}
