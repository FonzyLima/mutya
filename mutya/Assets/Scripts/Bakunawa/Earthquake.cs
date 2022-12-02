using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earthquake : MonoBehaviour
{
    public BakunawaSceneMovement playerMovement;
    public GameObject crack;
    public GameObject quake1;
    public GameObject quake2;
    public GameObject stunned;
    public GameObject player;
    public AudioSource quakeSFX;
    public SoundWaves soundWaves;

    void Start()
    {
        playerMovement = GetComponent<BakunawaSceneMovement>();
        // soundWaves = gameObject.GetComponent<SoundWaves>();
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {    
        soundWaves = gameObject.GetComponent<SoundWaves>();    
        if(other.tag == "crack")
        {
            playerMovement.canMove = false;
            // soundWaves.enabled = false;
            stunned.transform.position = new Vector3(player.transform.position.x+-.5f,player.transform.position.y+-.78f,0);
            stunned.SetActive(true);
            StartCoroutine(delayStun());
            
        }
    }
    public void spawnCrack(GameObject player){
        quakeSFX.Play();
        ShakeShake.Instance.ShakeCamera(5f, 8f);
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
        yield return new WaitForSeconds(8f);
        earthquake.SetActive(false);
    }
    public IEnumerator delayStun(){
        yield return new WaitForSeconds(8f);
        playerMovement.canMove = true;
        soundWaves.enabled = true;
        crack.SetActive(false);
        stunned.SetActive(false);
    }

}
