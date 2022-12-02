using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PlayerWinManananggal : MonoBehaviour
{
    private InventoryManager invManager;
    public DaytimeManager dtManager;
    public TeleportScene TPScene;

    private bool pickUpAllowed;
    private bool isDiscovered;
    private bool hasSalt;
    public GameObject boss;
    public GameObject transition;
    public GameObject timer;
    public GameObject gemPrefab;
    public GameObject handlePrefab;

    public GameObject WinDialogue;

    public GameObject Quest2;

    public GameObject pickUpText;

    public Vector3[] location;

    private void Start()
    {
        pickUpText.gameObject.SetActive(false);
        invManager = GameObject.Find("Player").GetComponent<InventoryManager>();

        Random rnd = new Random();
        int pos = rnd.Next(0, location.Length);
        if(location.Length != 0){
            gameObject.transform.position = location[pos];
        }
    }

    private void Update()
    {
        if (hasSalt && pickUpAllowed && Input.GetKeyDown(KeyCode.F)){
            print("Manananggal Defeated");
            Vector3 position = boss.transform.position;
            WinDialogue.SetActive(true);
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

            if (Quest2 != null)
            {
                Destroy(Quest2);
            }

            TPScene.addBossBeaten();
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
