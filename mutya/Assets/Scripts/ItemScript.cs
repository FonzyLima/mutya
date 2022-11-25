using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
    private InventoryManager invManager;
    private bool pickUpAllowed;
    private bool isDiscovered;
    private SpriteRenderer itemSprite;

    public GameObject pickUpText;

    public GameObject quest2;

    private void Start(){
        pickUpText.gameObject.SetActive(false);
        itemSprite = GetComponent<SpriteRenderer>();
        invManager = GameObject.Find("Player").GetComponent<InventoryManager>();
        gameObject.GetComponent<Renderer>().enabled = false;
    }

    private void Update(){
        if (isDiscovered && pickUpAllowed && Input.GetKeyDown(KeyCode.F)){
            PickUp();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.tag == "Player"){

            if (!isDiscovered){
                gameObject.GetComponent<Renderer>().enabled = true;
                isDiscovered = true;
                pickUpAllowed = true;
                pickUpText.gameObject.SetActive(true);
            }
            else
                pickUpAllowed = true;
                pickUpText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if (collision.tag == "Player"){
                pickUpAllowed = false;
                pickUpText.gameObject.SetActive(false);
        }
    }

    private void PickUp(){
        
        invManager.tikbalang_item += 1f;
        quest2.SetActive(false);
        Destroy(gameObject);
    }
}
