using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TikbalangDialogue : MonoBehaviour
{
    public PlayerMovement p;
    public TikbalangAI t;

    public GameObject bm;
    public GameObject TPQuest;
    public GameObject TPManager;

    public bool gameOver = false;

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

        if(SFXPlayer != null)
            SFXPlayer.Play();
            
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        p.setMove(false);
        t.setMove(false);

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
            if (gameOver)
            {
                SceneManager.LoadScene(0, LoadSceneMode.Single);
            }
            else
            {
                p.setMove(true);
                t.setMove(true);
                bm.SetActive(true);
                Destroy(gameObject);
            }
        }
    }

    public void gameOverSet (bool val)
    {
        gameOver = val;
    }
}   
