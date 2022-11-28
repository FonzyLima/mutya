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
    public Image monsterImage; // replace monster name

    public string[] monsters;
    public string[] descs;
    public Sprite[] images; // replace monster list

    public AudioSource BookSFX;


    void Start()
    {
        monsterName.text = string.Empty;
        monsterDesc.text = string.Empty;
        SpawnContent();
    }

    void SpawnContent()
    {   
        monsterName.text += monsters[pageCounter];
        monsterDesc.text += descs[pageCounter];
        monsterImage.color = new Color(1f, 1f, 1f, 1f);
        monsterImage.sprite = images[pageCounter];
    }

    void RemoveContent()
    {
        monsterName.text = string.Empty;
        monsterDesc.text = string.Empty;
        monsterImage.color = new Color(1f, 1f, 1f, 0f);
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
        RemoveContent();
        BookSFX.Play();
        animator.Play("Base Layer.FlipNext");
        pageCounter++;
        yield return new WaitForSeconds(0.5f);
        SpawnContent();
    }

    IEnumerator prevPage()
    {
        RemoveContent();
        BookSFX.Play();
        animator.Play("Base Layer.FlipPrev");
        pageCounter--;
        yield return new WaitForSeconds(0.5f);
        SpawnContent();
    }
}
