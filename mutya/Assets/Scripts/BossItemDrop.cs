using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossItemDrop : MonoBehaviour
{
    private Transform player;
    public float speed  = 5f;
    public float pickUpDistance = 1.5f;
    private InventoryManager invManager;


    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        invManager = GameObject.Find("Player").GetComponent<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if(distance > pickUpDistance)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
        );

        if(distance < 0.1f)
        {
            Destroy(gameObject);
            invManager.tikbalang_item += 1f;
        }
    }
}
