using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest5 : MonoBehaviour
{
    public GameObject Dialogue4;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Dialogue4.SetActive(true);
            Destroy(gameObject);
        }
    }
}
