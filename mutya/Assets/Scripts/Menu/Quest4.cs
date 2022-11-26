using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest4 : MonoBehaviour
{
    public GameObject Dialogue3;

    private int counter = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            counter++;
        }

        if (counter == 2)
        {
            Dialogue3.SetActive(true);
            Destroy(gameObject);
        }
    }
}
