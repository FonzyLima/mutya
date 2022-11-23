using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public int sceneBuildIndex;
    public GameObject gameObject;
    
    static bool created = false;

    void Awake()
    {
        if (created)
        {
            gameObject = GameObject.Find("Timeline");
            if (gameObject)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        print(other.tag);
        if(other.tag == "Player")
        {
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
            created = true;
        }
    }
}
