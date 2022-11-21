using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakunawaSpawner : MonoBehaviour
{   
    public GameObject bakunawa;
    public GameObject moon0;
    public GameObject moon1;
    public GameObject moon2;
    public GameObject moon3;
    public GameObject moon4;
    public GameObject moon5;
    public GameObject moon6;
    public float timer = 210;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        

        
    }
    void MoveMoon(GameObject moon){
        if(moon.activeSelf){
                
                bakunawa.transform.Translate(Vector2.up*speed*Time.deltaTime);
            }
            if(bakunawa.transform.position.y > GameObject.FindGameObjectWithTag("MainCamera").transform.position.y+10){
                bakunawa.transform.position = new Vector3(Random.Range(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x-10,GameObject.FindGameObjectWithTag("MainCamera").transform.position.x+10),-28,transform.position.z);
                moon.SetActive(false);
            }
    }

    // Update is called once per frame
    void Update()
    {   
        GameObject[] moons;
        moons = GameObject.FindGameObjectsWithTag("Moon");
        for(int i=0;i<moons.Length;i++){
            moons[i].transform.position = new Vector3(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x+i,GameObject.FindGameObjectWithTag("MainCamera").transform.position.y+4,0);
        }
        if(timer>0){
            timer -= Time.deltaTime;
            print(timer);
        }

        if(timer<=180){
            MoveMoon(moon6);
            
        }
        if(timer<=150){
            MoveMoon(moon5);
            
        }
        if(timer<=120){
            MoveMoon(moon4);
            
        }
        if(timer<=90){
            MoveMoon(moon3);
            
        }
        if(timer<=60){
            MoveMoon(moon2);  
        }
        if(timer<=30){
            MoveMoon(moon1);
            
        }
        if(timer<=0){
            MoveMoon(moon0);
        }
        
    }
}
