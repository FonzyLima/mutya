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
            if(moon6.activeSelf){
                bakunawa.transform.Translate(Vector2.up*speed*Time.deltaTime);
            }
            if(bakunawa.transform.position.y > GameObject.FindGameObjectWithTag("MainCamera").transform.position.y+10){
                bakunawa.transform.position = new Vector3(Random.Range(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x-10,GameObject.FindGameObjectWithTag("MainCamera").transform.position.x+10),-28,transform.position.z);
                moon6.SetActive(false);
            }
            
        }
        if(timer<=150){
            if(moon5.activeSelf){
                bakunawa.transform.Translate(Vector2.up*speed*Time.deltaTime);
            }
            if(bakunawa.transform.position.y > GameObject.FindGameObjectWithTag("MainCamera").transform.position.y+10){
                bakunawa.transform.position = new Vector3(Random.Range(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x-10,GameObject.FindGameObjectWithTag("MainCamera").transform.position.x+10),-28,transform.position.z);
                moon5.SetActive(false);
            }
            
        }
        if(timer<=120){
            if(moon4.activeSelf){
                bakunawa.transform.Translate(Vector2.up*speed*Time.deltaTime);
            }
            if(bakunawa.transform.position.y > GameObject.FindGameObjectWithTag("MainCamera").transform.position.y+10){
                bakunawa.transform.position = new Vector3(Random.Range(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x-10,GameObject.FindGameObjectWithTag("MainCamera").transform.position.x+10),-28,transform.position.z);
                moon4.SetActive(false);
            }
            
        }
        if(timer<=90){
            if(moon3.activeSelf){
                bakunawa.transform.Translate(Vector2.up*speed*Time.deltaTime);
            }
            if(bakunawa.transform.position.y > GameObject.FindGameObjectWithTag("MainCamera").transform.position.y+10){
                bakunawa.transform.position = new Vector3(Random.Range(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x-10,GameObject.FindGameObjectWithTag("MainCamera").transform.position.x+10),-28,transform.position.z);
                moon3.SetActive(false);
            }
            
        }
        if(timer<=60){
            if(moon2.activeSelf){
                bakunawa.transform.Translate(Vector2.up*speed*Time.deltaTime);
            }
            if(bakunawa.transform.position.y > GameObject.FindGameObjectWithTag("MainCamera").transform.position.y+10){
                bakunawa.transform.position = new Vector3(Random.Range(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x-10,GameObject.FindGameObjectWithTag("MainCamera").transform.position.x+10),-28,transform.position.z);
                moon2.SetActive(false);
            }
            
        }
        if(timer<=30){
            if(moon1.activeSelf){
                bakunawa.transform.Translate(Vector2.up*speed*Time.deltaTime);
            }
            if(bakunawa.transform.position.y > GameObject.FindGameObjectWithTag("MainCamera").transform.position.y+10){
                bakunawa.transform.position = new Vector3(Random.Range(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x-10,GameObject.FindGameObjectWithTag("MainCamera").transform.position.x+10),-28,transform.position.z);
                moon1.SetActive(false);
            }
            
        }
        if(timer<=0){
            if(moon0.activeSelf){
                bakunawa.transform.Translate(Vector2.up*speed*Time.deltaTime);
            }
            if(bakunawa.transform.position.y > GameObject.FindGameObjectWithTag("MainCamera").transform.position.y+10){
                bakunawa.transform.position = new Vector3(Random.Range(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x-10,GameObject.FindGameObjectWithTag("MainCamera").transform.position.x+10),-28,transform.position.z);
                moon0.SetActive(false);
            }
            
        }
        


    }
}
