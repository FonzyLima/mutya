using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryManager : MonoBehaviour
{
    public float tikbalang_item; 

    // public GameObject DialogueBakunawa
    public GameObject DialogueManananggal;
    public GameObject DialogueTikbalang;

    private int curScene;

    // Start is called before the first frame update
    void Start()
    {
        tikbalang_item = 0f;
        curScene = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        // if bakunawa
        // if (curScene == 1 && tikbalang_item == 3f)
        // {
        //     if (DialogueManananggal != null)
        //     {
        //         DialogueManananggal.SetActive(true);
        //     }
        // }

        // if manananggal
        if (curScene == 2 && tikbalang_item == 3f)
        {
            if (DialogueManananggal != null)
            {
                DialogueManananggal.SetActive(true);
            }
        }

        // if tikbalang
        if (curScene == 4 && tikbalang_item == 2f)
        {
            if (DialogueTikbalang != null)
            {
                DialogueTikbalang.SetActive(true);
            }
        }
        
    }
}
