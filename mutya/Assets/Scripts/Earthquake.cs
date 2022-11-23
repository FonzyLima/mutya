using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earthquake : MonoBehaviour
{
    public BakunawaSceneMovement playerMovement;
    void Start()
    {
        playerMovement = GetComponent<BakunawaSceneMovement>();
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {        
        if(other.tag == "crack")
        {
            playerMovement.canMove = false;
        }
    }

}
