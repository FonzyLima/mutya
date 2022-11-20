using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakunawaSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(transform.position.y > GameObject.FindGameObjectWithTag("MainCamera").transform.position.y+10){
            transform.position = new Vector3(Random.Range(GameObject.FindGameObjectWithTag("MainCamera").transform.position.x-10,GameObject.FindGameObjectWithTag("MainCamera").transform.position.x+10),GameObject.FindGameObjectWithTag("MainCamera").transform.position.y-12,transform.position.z);
        }
        transform.Translate(Vector2.up*speed*Time.deltaTime);

    }
}
