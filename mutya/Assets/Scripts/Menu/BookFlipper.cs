using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BookFlipper : MonoBehaviour
{
    public Animator animator;
    public int pageCounter = 0;

    public TextMeshProUGUI monsterName;
    public TextMeshProUGUI monsterDesc;

    public string[] monsters;
    public string[] descs;

    void Start()
    {
        monsterName.text = string.Empty;
        monsterDesc.text = string.Empty;
        SpawnText();
    }

    void SpawnText()
    {   
        monsterName.text += monsters[pageCounter];
        monsterDesc.text += descs[pageCounter];
    }

    void RemoveText()
    {
        monsterName.text = string.Empty;
        monsterDesc.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && pageCounter < 9)
        {
            RemoveText();
            animator.Play("Base Layer.FlipNext");
            pageCounter++;
            SpawnText();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && pageCounter > 0)
        {
            RemoveText();
            animator.Play("Base Layer.FlipPrev");
            pageCounter--;
            SpawnText();
        }
    }
}
