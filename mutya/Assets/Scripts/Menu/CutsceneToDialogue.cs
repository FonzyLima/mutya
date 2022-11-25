using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public GameObject Button;

    public GameObject MenuDialogue;

    private float timer = 41;
    private bool sceneDone = false;

    // Update is called once per frame
    void Update()
    {
        if (sceneDone)
        {
            Destroy(BG);
            Destroy(Title);
            Destroy(Panel1);
            Destroy(Bughaw);
            Destroy(Mabaya);
            Destroy(Esmeralda);
            Destroy(Panel2);
            Destroy(Panel3);
            Destroy(Intro1);
            Destroy(Intro2);
            Destroy(Intro3);
            Destroy(Intro4);
            Destroy(Intro5);

            if (Button)
            {
                Destroy(Button);
            }

            MenuDialogue.SetActive(true);
        }
    }

    public void skipCutscene()
    {
        timer = 0;
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
