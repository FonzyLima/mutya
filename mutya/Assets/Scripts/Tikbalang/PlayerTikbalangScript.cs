using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTikbalangScript : MonoBehaviour{
    private InventoryManager invManager;

    public GameObject tikbalang;
    private Transform tikbalangPos;

    private Vector2 currentPos; 

    public float attackDistance;   
    private bool isDestroyed;
    public GameObject jadePrefab;
    // Start is called before the first frame update
    void Start()
    {
        invManager = GetComponent<InventoryManager>();

        tikbalangPos = tikbalang.GetComponent<Transform>(); // position of tikbalang
        currentPos = GetComponent<Transform>().position; // position of player
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDestroyed && Input.GetKeyDown(KeyCode.F) && invManager.tikbalang_item >= 1f && Vector2.Distance(transform.position, tikbalangPos.position) < attackDistance){
            Vector3 position = tikbalang.transform.position;
            Destroy(tikbalang);
            isDestroyed = true;
            GameObject jade = Instantiate(jadePrefab);
            jade.transform.position = position;
        }
    }
}
