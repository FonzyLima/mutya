using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest3 : MonoBehaviour
{
    private int counter = 0;

    public GameObject Dialogue2;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            counter++;
        }

        if (counter == 2)
        {
            Dialogue2.SetActive(true);
            Destroy(gameObject);
        }
    }
}
