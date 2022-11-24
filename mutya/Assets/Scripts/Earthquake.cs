using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earthquake : MonoBehaviour
{
    public BakunawaSceneMovement playerMovement;
    public GameObject crack;
    void Start()
    {
        playerMovement = GetComponent<BakunawaSceneMovement>();
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {        
        if(other.tag == "crack")
        {
            playerMovement.canMove = false;
            StartCoroutine(delay());

        }
    }
    public void spawnCrack(GameObject player){
        crack.SetActive(true);
        float[] randomX = new float[] {-4.79f,4.89f};
        float[] randomY = new float[] {-3.54f,2.79f}; 
        crack.transform.position = new Vector3(player.transform.position.x+randomX[Random.Range(0,2)],player.transform.position.y+randomY[Random.Range(0,2)],0);
    }

    public IEnumerator delay(){
        yield return new WaitForSeconds(3f);
        playerMovement.canMove = true;
        crack.SetActive(false);
    }

}
