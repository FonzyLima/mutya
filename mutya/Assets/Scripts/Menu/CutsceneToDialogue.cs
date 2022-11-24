using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneToDialogue : MonoBehaviour
{
    public GameObject Image;
    public GameObject Title;
    public GameObject Dummy1;
    public GameObject Dummy2;
    public GameObject Dummy3;
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
            Image.SetActive(false);
            Title.SetActive(false);
            Dummy1.SetActive(false);
            Dummy2.SetActive(false);
            Dummy3.SetActive(false);
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
