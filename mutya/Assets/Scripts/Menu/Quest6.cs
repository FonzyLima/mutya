using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest6 : MonoBehaviour
{
    public GameObject Dialogue6;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Dialogue6.SetActive(true);
            Destroy(gameObject);
        }
    }
}
