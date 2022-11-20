using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public GameObject moon0;
    public GameObject moon1;
    public GameObject moon2;
    public GameObject moon3;
    public GameObject moon4;
    public GameObject moon5;
    public GameObject moon6;
    public float timer = 210;

    // Update is called once per frame
    void Update()
    {
        if(timer>0){
            timer -= Time.deltaTime;
        }
        if(timer<=180){
            moon6.SetActive(false);
        }
        if(timer<=150){
            moon5.SetActive(false);
        }
        if(timer<=120){
            moon4.SetActive(false);
        }
        if(timer<=90){
            moon3.SetActive(false);
        }
        if(timer<=60){
            moon2.SetActive(false);
        }
        if(timer<=30){
            moon1.SetActive(false);
        }
        if(timer<=0){
            moon0.SetActive(false);
        }
    }
}
