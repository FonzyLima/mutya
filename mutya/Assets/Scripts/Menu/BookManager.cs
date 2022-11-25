using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookManager : MonoBehaviour
{
    public GameObject Book;

    public PlayerMovement p; // temporary, simulates game pause

    public bool equipped = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (equipped)
            {
                p.setMove(true);
                Book.SetActive(false);
            }
                
            else
            {
                p.setMove(false);
                Book.SetActive(true);
            }
                
            equipped = !equipped;
        }
    }
}
