using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest2 : MonoBehaviour
{
    public GameObject Book;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Input.ResetInputAxes();
            gameObject.SetActive(false);
            Book.SetActive(false);
        }
    }
}
