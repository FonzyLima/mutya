using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportScene : MonoBehaviour
{
    public static int bossBeaten = 3;

    public Respawn respawn;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (SceneManager.GetActiveScene().buildIndex == 0) // if player is in menu
            {
                TeleportToBoss(bossBeaten + 1);
                if (respawn != null)
                {
                    respawn.setterMenu(true);
                }
            }
            else // if player is not in menu (boss map)
            {
                TeleportToMenu();
            }
        }
    }

    void TeleportToBoss(int boss)
    {
        SceneManager.LoadScene(boss, LoadSceneMode.Single);
    }

    void TeleportToMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public int getBossDefeat()
    {
        return bossBeaten;
    }

    public void addBossBeaten()
    {
        bossBeaten++;
    }
}
