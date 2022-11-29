using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuDialogue : MonoBehaviour
{
    public PlayerMovement player;

    public GameObject Quest1;

    public GameObject Quest2;
    public GameObject Book;

    public GameObject Quest4;

    public GameObject Quest5;

    public GameObject Dialogue5;

    public GameObject Quest6;

    public GameObject TPQuest;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public AudioSource SFXPlayer;
    public AudioClip hirayaTalk;
    public AudioClip mariaTalk;

    public string[] nameLines;
    public string[] dialogueLines;
    
    public float textSpeed;

    private int nameIndex;
    private int dialogueIndex;

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = string.Empty;
        dialogueText.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        player.setMove(false);

        if (Input.GetMouseButtonDown(0))
        {
            if (dialogueText.text == dialogueLines[dialogueIndex])
            {
                NextNameLine();
                NextDialogueLine();
            }
            else
            {
                StopAllCoroutines();
                nameText.text = nameLines[nameIndex];
                dialogueText.text = dialogueLines[dialogueIndex];
                SFXPlayer.Stop();
            }
        }
    }

    void StartDialogue()
    {
        nameIndex = 0;
        dialogueIndex = 0;
        StartCoroutine(TypeNameLine());
        StartCoroutine(TypeDialogueLine());
    }

    IEnumerator TypeNameLine()
    {
        foreach (char c in nameLines[nameIndex].ToCharArray())
        {
            nameText.text += c;
            yield return new WaitForSeconds(textSpeed); 
        }
    }

    IEnumerator TypeDialogueLine()
    {
        if (nameLines[nameIndex] == "MARIA")
        {
            SFXPlayer.clip = mariaTalk;
        }
        if (nameLines[nameIndex] == "HIRAYA")
        {
            SFXPlayer.clip = hirayaTalk;
        }

        SFXPlayer.loop = true;
        SFXPlayer.Play();

        foreach (char c in dialogueLines[dialogueIndex].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        SFXPlayer.Stop();
    }

    void NextNameLine()
    {
        if (nameIndex < nameLines.Length - 1)
        {
            nameIndex++;
            nameText.text = string.Empty;
            StartCoroutine(TypeNameLine());
        }
    }

    void NextDialogueLine()
    {
        if (dialogueIndex < dialogueLines.Length - 1)
        {
            dialogueIndex++;
            dialogueText.text = string.Empty;
            StartCoroutine(TypeDialogueLine());
        }
        else
        {
            if (Quest1 != null)
            {
                Quest1.SetActive(true);
            }
            if (Quest2 != null)
            {
                Quest2.SetActive(true);
            }
            if (Book != null)
            {
                Book.SetActive(true);
            }
            if (Quest4 != null)
            {
                Quest4.SetActive(true);
            }
            if (Quest5 != null)
            {
                Quest5.SetActive(true);
            }
            if (Dialogue5 != null)
            {
                Dialogue5.SetActive(true);
            }
            if (Quest6 != null)
            {
                Quest6.SetActive(true);
            }
            if (TPQuest != null)
            {
                TPQuest.SetActive(true);
            }
            Destroy(gameObject);
            player.setMove(true);
        }
    }
}   
