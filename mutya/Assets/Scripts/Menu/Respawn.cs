using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public static bool leftMenu = false;

    public GameObject RespawnDialogue;

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

    // Start is called before the first frame update
    void Start()
    {
        if (leftMenu)
        {
            RespawnDialogue.SetActive(true);
        }
        else
        {
            BG.SetActive(true);
            Title.SetActive(true);
            Panel1.SetActive(true);
            Bughaw.SetActive(true);
            Mabaya.SetActive(true);
            Esmeralda.SetActive(true);
            Panel2.SetActive(true);
            Panel3.SetActive(true);
            Intro1.SetActive(true);
            Intro2.SetActive(true);
            Intro3.SetActive(true);
            Intro4.SetActive(true);
            Intro5.SetActive(true);
            Button.SetActive(true);
        }
    }

    public void setterMenu (bool val)
    {
        leftMenu = val;
    }
}
