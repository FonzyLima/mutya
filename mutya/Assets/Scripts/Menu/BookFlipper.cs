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
    // public Image monsterImage; // replace monster name

    public string[] monsters;
    public string[] descs;
    // public Image[] images; // replace monster list

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
            StartCoroutine(nextPage());
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && pageCounter > 0)
        {
            StartCoroutine(prevPage());
        }
    }

    IEnumerator nextPage()
    {
        RemoveText();
        animator.Play("Base Layer.FlipNext");
        pageCounter++;
        yield return new WaitForSeconds(0.5f);
        SpawnText();
    }

    IEnumerator prevPage()
    {
        RemoveText();
        animator.Play("Base Layer.FlipPrev");
        pageCounter--;
        yield return new WaitForSeconds(0.5f);
        SpawnText();
    }
}
