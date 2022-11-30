using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public static bool leftMenu = false;
    public static bool diedBoss = false;

    public TeleportScene TPScene;

    public GameObject RespawnDialogue;

    public GameObject winBakunawa;
    public GameObject winManananggal;
    public GameObject winTikbalang;

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

    public GameObject bm;

    private int bossDefeat;

    // Start is called before the first frame update
    void Start()
    {
        if (leftMenu)
        {
            // if died
            if (diedBoss)
            {
                RespawnDialogue.SetActive(true);
                diedBoss = false;
            }

            // if win
            else
            {
                bossDefeat = TPScene.getBossDefeat();
                if (bossDefeat == 1) // if bakunawa defeated, spawn bakunawa dialogue
                {
                    winBakunawa.SetActive(true);
                }
                if (bossDefeat == 2) // if manananggal defeated, spawn manananggal dialogue
                {
                    winManananggal.SetActive(true);
                }
                if (bossDefeat == 4) // if tikbalang defeated, spawn tikbalang dialogue
                {
                    winTikbalang.SetActive(true);
                }
            }
            
            bm.SetActive(true);
        }
        else
        {
            if (BG != null)
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
    }

    public void setterMenu (bool val)
    {
        leftMenu = val;
    }

    public void setterDead (bool val)
    {
        diedBoss = val;
    }
}
