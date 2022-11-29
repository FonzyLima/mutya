using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueScript : MonoBehaviour
{

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public string[] nameLines;
    public string[] dialogueLines;

    private int nameIndex;
    private int dialogueIndex;

    public float textSpeed;

    private bool active;

    //Start is called before the first frame update
    void Start()
    {
        active = false;
        nameText.text = string.Empty;
        dialogueText.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if (!active && gameObject.activeSelf){
            active = true;
            StartCoroutine(TypeNameLine());
            StartCoroutine(TypeDialogueLine());
        }
    }

    IEnumerator TypeNameLine()
    {
        foreach (char c in nameLines[nameIndex].ToCharArray())// nameLines[nameIndex].ToCharArray()
        {
            Debug.Log("NAME - " + c);
            nameText.text += c;
            yield return new WaitForSeconds(textSpeed); 
        }
    }

    IEnumerator TypeDialogueLine()
    {
        // if (nameLines[nameIndex] == "MARIA")
        // {
        //     SFXPlayer.clip = mariaTalk;
        // }
        // if (nameLines[nameIndex] == "HIRAYA")
        // {
        //     SFXPlayer.clip = hirayaTalk;
        // }

        // SFXPlayer.loop = true;
        // SFXPlayer.Play();

        foreach (char c in dialogueLines[dialogueIndex].ToCharArray())
        {
            Debug.Log("DIAL - " + c);
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        // SFXPlayer.Stop();
    }
}
