using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earthquake : MonoBehaviour
{
    public BakunawaSceneMovement playerMovement;
    public GameObject crack;
    public GameObject quake1;
    public GameObject quake2;
    void Start()
    {
        playerMovement = GetComponent<BakunawaSceneMovement>();
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {        
        if(other.tag == "crack")
        {
            playerMovement.canMove = false;
            StartCoroutine(delayStun());
            
        }
    }
    public void spawnCrack(GameObject player){
        ShakeShake.Instance.ShakeCamera(5f, 5f);
        GameObject[] earthquakes;
        quake1.SetActive(true);
        quake2.SetActive(true);
        earthquakes = GameObject.FindGameObjectsWithTag("Earthquake");
        int index;
        index = Random.Range(0,2);
        quake1.SetActive(false);
        quake2.SetActive(false);
        earthquakes[index].SetActive(true);
        StartCoroutine(delaySpawn(earthquakes[index]));
    }

    public IEnumerator delaySpawn(GameObject earthquake){
        yield return new WaitForSeconds(5f);
        earthquake.SetActive(false);
    }
    public IEnumerator delayStun(){
        yield return new WaitForSeconds(5f);
        playerMovement.canMove = true;
        crack.SetActive(false);
    }

}
