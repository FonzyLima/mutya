using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestRemover : MonoBehaviour
{
    private float timer = 3;
    public GameObject thisQuest;

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        else
        {
            if (thisQuest != null)
            {
                Destroy(thisQuest);
            }
        }
    }
}
