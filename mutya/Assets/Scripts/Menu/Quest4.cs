using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest4 : MonoBehaviour
{
    public GameObject Dialogue3;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Dialogue3.SetActive(true);
            Destroy(gameObject);
        }
    }
}
