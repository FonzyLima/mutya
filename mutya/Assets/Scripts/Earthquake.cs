using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earthquake : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        print(other.tag);
        if(other.tag == "Player")
        {
            print("earthquakeeee");
        }
    }

}
