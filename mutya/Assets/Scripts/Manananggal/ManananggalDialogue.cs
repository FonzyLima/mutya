using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ManananggalDialogue : MonoBehaviour
{
    public PlayerMovement player;
    public PlayerManananggalMechanic mechanic;
    public DaytimeManager dtManager;
    public ManananggalMovement manananggal;
    public Timer mTimer;

    public GameObject bm;

    public GameObject Quest1;
    public GameObject Quest2;
    public GameObject TPQuest;
    public GameObject TPManager;

    public bool gameOver = false;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public AudioSource SFXPlayer;
    public AudioClip hirayaTalk;
    public AudioClip mariaTalk;
    
    public AudioSource playBGM;

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

        if(playBGM != null)
            playBGM.Play();
            
        StartDialogue();
        Input.ResetInputAxes();
    }

    // Update is called once per frame
    void Update()
    {
        player.setMove(false);
        mechanic.pauseMechanic(true);
        dtManager.pauseDaytime(true);
        manananggal.pauseManananggal(true);
        mTimer.pauseTimer(true);
        bm.SetActive(false);

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
                if (Quest1 != null)
                {
                    Quest1.SetActive(true);
                }

                if (Quest2 != null)
                {
                    Quest2.SetActive(true);
                }

                if (TPQuest != null && TPManager != null)
                {
                    TPQuest.SetActive(true);
                    TPManager.SetActive(true);
                }

                player.setMove(true);
                mechanic.pauseMechanic(false);
                dtManager.pauseDaytime(false);
                manananggal.pauseManananggal(false);
                mTimer.pauseTimer(false);
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
