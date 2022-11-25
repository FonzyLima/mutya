using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookManager : MonoBehaviour
{
    public GameObject Book;
    public GameObject Player;

    public bool equipped = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (equipped)
            {
                Book.SetActive(false);
            }
                
            else
            {
                Book.SetActive(true);
                Book.transform.position = Player.transform.position;
            }
                
            equipped = !equipped;
        }
    }
}
