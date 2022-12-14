using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakunawaSpawner : MonoBehaviour
{   
    public GameObject player;
    public GameObject crack;
    public GameObject bakunawa;
    public GameObject moon0;
    public GameObject moon1;
    public GameObject moon2;
    public GameObject moon3;
    public GameObject moon4;
    public GameObject moon5;
    public GameObject moon6;
    public GameObject finalGameManager;

    public GameObject Dialogue3;
    public GameObject Dialogue4;
    public GameObject Quest1;

    public BakunawaDialogue dialogue;
    public Respawn respawn;
    public GameObject DeathScreen;
    public GameObject DeathDialogue;

    public InventoryManager inventory;
    public float timer = 210;
    public float speed;
    public Earthquake earthquake;

    public bool Pause = false;

    void MoveMoon(GameObject moon){
        if(moon.activeSelf){
                if(bakunawa.transform.position.y>13.6){
                    bakunawa.transform.position = new Vector3(Random.Range(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x-10,GameObject.FindGameObjectWithTag("MainCamera").transform.position.x+10),-28,transform.position.z);
                    earthquake.spawnCrack(player);
                }
                bakunawa.transform.Translate(Vector2.up*speed*Time.deltaTime);
            }
            if(bakunawa.transform.position.y > 13.6){
                moon.SetActive(false);
                
            }
    }
    void MoveMoon2(GameObject moon){
        if(moon.activeSelf){
            moon.SetActive(false);
            earthquake.spawnCrack(player);
        }
        if(bakunawa.transform.position.y>13.6){
            bakunawa.transform.position = new Vector3(Random.Range(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x-10,GameObject.FindGameObjectWithTag("MainCamera").transform.position.x+10),-28,transform.position.z);
        }
        bakunawa.transform.Translate(Vector2.up*speed*Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {   
        //delay this then have a void start for starting cutscene?
        GameObject[] moons;
        moons = GameObject.FindGameObjectsWithTag("Moon");

        if(inventory.tikbalang_item == 1){
            if (Dialogue3 != null)
            {
                Dialogue3.SetActive(true);
            }
        }

        if(inventory.tikbalang_item == 2){
            // this is the transition to the boss fight
            if (Dialogue4 != null)
            {
                Dialogue4.SetActive(true);
                Destroy(Quest1);
            }
            finalGameManager.SetActive(true);
        }
        for(int i=0;i<moons.Length;i++){
            moons[i].transform.position = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x+12-i,GameObject.FindGameObjectWithTag("MainCamera").transform.position.y+6,0);
        }
        
        if (!Pause)
        {
            if(timer>0){
                timer -= Time.deltaTime;
            }

            if(timer<=180){
                //add nalang siguro another boolean for like if not pause ganun
                if(inventory.tikbalang_item == 2){
                    MoveMoon2(moon6);
                }
                //then make this else if with the pause boolean
                else{
                    MoveMoon(moon6);
                }
            }
            if(timer<=150){
                if(inventory.tikbalang_item == 2){
                    MoveMoon2(moon5);
                }
                else{
                    MoveMoon(moon5);
                }
                
            }
            if(timer<=120){
                if(inventory.tikbalang_item == 2){
                    MoveMoon2(moon4);
                }
                else{
                    MoveMoon(moon4);
                }
                
            }
            if(timer<=90){
                if(inventory.tikbalang_item == 2){
                    MoveMoon2(moon3);
                }
                else{
                    MoveMoon(moon3);
                }
                
            }
            if(timer<=60){
                if(inventory.tikbalang_item == 2){
                    MoveMoon2(moon2);
                }
                else{
                    MoveMoon(moon2);
                }  
            }
            if(timer<=30){
                if(inventory.tikbalang_item == 2){
                    MoveMoon2(moon1);
                }
                else{
                    MoveMoon(moon1);
                }
                
            }
            if(timer<=0){
                
                if(inventory.tikbalang_item == 2){
                    MoveMoon2(moon0);
                }
                else{
                    MoveMoon(moon0);
                }
                //game over
                DeathScreen.SetActive(true);
                DeathDialogue.SetActive(true);
                dialogue.gameOverSet(true);
                respawn.setterDead(true);
            }
        }
    }

    public void pauseBSpawner (bool val)
    {
        Pause = val;
    }
}
