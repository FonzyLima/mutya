using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportScene : MonoBehaviour
{
    public static int bossBeaten = 0;

    public Respawn respawn;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (SceneManager.GetActiveScene().buildIndex == 0) // if player is in menu
            {
                TeleportToBoss(bossBeaten + 1);
            }
            else // if player is not in menu (boss map)
            {
                TeleportToMenu();
            }
        }

        respawn.setterMenu(true);
    }

    void TeleportToBoss(int boss)
    {
        SceneManager.LoadScene(boss, LoadSceneMode.Single);
    }

    void TeleportToMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
