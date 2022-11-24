using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneToDialogue : MonoBehaviour
{
    public GameObject BG;
    public GameObject Title;

    public GameObject Panel1;
    public GameObject Bughaw;
    public GameObject Mabaya;
    public GameObject Esmeralda;

    public GameObject Panel2;
    public GameObject Panel3;

    public GameObject Intro1;
    public GameObject Intro2;
    public GameObject Intro3;
    public GameObject Intro4;
    public GameObject Intro5;

    public GameObject MenuDialogue;

    private float timer = 41;
    private bool sceneDone = false;

    // Update is called once per frame
    void Update()
    {
        if (sceneDone)
        {
            BG.SetActive(false);
            Title.SetActive(false);
            Panel1.SetActive(false);
            Bughaw.SetActive(false);
            Mabaya.SetActive(false);
            Esmeralda.SetActive(false);
            Panel2.SetActive(false);
            Panel3.SetActive(false);
            Intro1.SetActive(false);
            Intro2.SetActive(false);
            Intro3.SetActive(false);
            Intro4.SetActive(false);
            Intro5.SetActive(false);

            MenuDialogue.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        if (timer > 0)
        {
            timer -= Time.fixedDeltaTime;
        }
        else
        {
            sceneDone = true;
        }
    }
}
