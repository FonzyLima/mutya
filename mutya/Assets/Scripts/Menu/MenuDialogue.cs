using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuDialogue : MonoBehaviour
{
    public PlayerMovement player;
    public GameObject Quest1;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

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
        player.setMove(false);
    }

    // Update is called once per frame
    void Update()
    {
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
        foreach (char c in dialogueLines[dialogueIndex].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed); 
        }
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
            Quest1.SetActive(true);
            gameObject.SetActive(false);
            player.setMove(true);
        }
    }
}   
