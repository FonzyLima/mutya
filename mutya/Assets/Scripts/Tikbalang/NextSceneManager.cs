using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneManager : MonoBehaviour
{
    public TeleportScene TPScene;

    // Update is called once per frame
    void Update()
    {
        TPScene.addBossBeaten();
        SceneManager.LoadScene(4, LoadSceneMode.Single);
    }
}
