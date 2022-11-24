using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest1 : MonoBehaviour
{
    public MenuDialogueManager mdm;

    private bool wPressed = false;
    private bool aPressed = false;
    private bool sPressed = false;
    private bool dPressed = false;

    void Update()
    {
        if (mdm.getQ1()) 
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

            if (wPressed && aPressed && sPressed && dPressed)
            {
                Input.ResetInputAxes();
                mdm.setD1(true);
                gameObject.SetActive(false);
            }
        }
    }
}
