using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BookManager : MonoBehaviour
{
    public GameObject Book;

    public PlayerMovement p;

    // bakunawa assets
    public BakunawaSceneMovement pBakunawa;
    public BakunawaSpawner bakunawaSpawn;
    public SoundWaves soundWaves;

    // manananaggal assets
    public PlayerManananggalMechanic mechanic;
    public DaytimeManager dtManager;
    public ManananggalMovement manananggal;
    public Timer mTimer;

    public bool equipped = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (equipped)
            {
                if (p != null)
                {
                    p.setMove(true);
                }
                if (pBakunawa != null);
                {
                    pBakunawa.setMove(true);
                    bakunawaSpawn.pauseBSpawner(false);
                    soundWaves.pauseSound(false);
                }
                if (mechanic != null && dtManager != null && manananggal != null && mTimer != null)
                {
                    mechanic.pauseMechanic(false);
                    dtManager.pauseDaytime(false);
                    manananggal.pauseManananggal(false);
                    mTimer.pauseTimer(false);
                }
                Book.SetActive(false);
            }
                
            else
            {
                if (p != null)
                {
                    p.setMove(false);
                }
                if (pBakunawa != null);
                {
                    pBakunawa.setMove(false);
                    bakunawaSpawn.pauseBSpawner(true);
                    soundWaves.pauseSound(true);
                }
                if (mechanic != null && dtManager != null && manananggal != null && mTimer != null)
                {
                    mechanic.pauseMechanic(true);
                    dtManager.pauseDaytime(true);
                    manananggal.pauseManananggal(true);
                    mTimer.pauseTimer(true);
                }
                Book.SetActive(true);
            }
                
            equipped = !equipped;
        }
    }
}
