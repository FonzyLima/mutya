using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWinManananggal : MonoBehaviour
{
    private InventoryManager invManager;
    private bool pickUpAllowed;
    private bool isDiscovered;
    private bool hasSalt;
    public GameObject boss;


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
            Destroy(boss);
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
