using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWinManananggal : MonoBehaviour
{
    private InventoryManager invManager;
    public DaytimeManager dtManager;

    private bool pickUpAllowed;
    private bool isDiscovered;
    private bool hasSalt;
    public GameObject boss;
    public GameObject transition;
    public GameObject timer;
    public GameObject gemPrefab;
    public GameObject handlePrefab;


    public GameObject pickUpText;

    private void Start()
    {
        pickUpText.gameObject.SetActive(false);
        invManager = GameObject.Find("Player").GetComponent<InventoryManager>();
    }

    private void Update()
    {
        if (hasSalt && pickUpAllowed && Input.GetKeyDown(KeyCode.F)){
            print("Manananggal Defeated");
            Vector3 position = boss.transform.position;
            Destroy(gameObject);
            Destroy(boss);
            transition.SetActive(true);
            dtManager.pauseDaytime(true);
            timer.SetActive(false);
            GameObject gem = Instantiate(gemPrefab);
            gem.transform.position = position;

            GameObject handle = Instantiate(handlePrefab);
            position.y += 2f;
            handle.transform.position = position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"){
            hasSalt = invManager.tikbalang_item == 1;
            if(hasSalt){
                pickUpAllowed = true;
                pickUpText.gameObject.SetActive(true);
            }
            else{
                pickUpAllowed = false;
                pickUpText.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if (collision.tag == "Player"){
                pickUpAllowed = false;
                pickUpText.gameObject.SetActive(false);
        }
    }
}
