using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest3 : MonoBehaviour
{
    public GameObject Dialogue2;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Dialogue2.SetActive(true);
            Destroy(gameObject);
        }
    }
}
