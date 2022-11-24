using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TikbalangAI : MonoBehaviour
{
    public Transform[] waypoints;

    [SerializeField]
    private float moveSpeed = 4f;

    [SerializeField]
    private int wIdx = 1;
    // Start is called before the first frame update
    private void Start()
    {
        transform.position = waypoints[0].transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
    }

    private void Move(){
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
