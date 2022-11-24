using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    private bool wPressed = false;
    private bool aPressed = false;
    private bool sPressed = false;
    private bool dPressed = false;

    public void startQuest1()
    {
        gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            wPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            aPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            sPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            dPressed = true;
        }
    }
}
