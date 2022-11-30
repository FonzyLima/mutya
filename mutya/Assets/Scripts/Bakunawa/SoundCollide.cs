using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCollide : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject finalGameManager;

    public TeleportScene TPScene;
    public GameObject WinDialogue;
    public GameObject whipTailPrefab;
    public GameObject garnetPrefab;

    public float currentHealth = 10f;
    public float maxHealth = 10f;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) 
    {        
        if(other.tag == "Enemy")
        {
            currentHealth-=1f;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth==0){
            //win condition
            print("Game Over!");
            TPScene.addBossBeaten();
            gameManager.SetActive(false);
            finalGameManager.SetActive(false);
            WinDialogue.SetActive(true);
            gameObject.SetActive(false);

            Vector3 position = new Vector3(-1.64f, -1.47f, 0);
            GameObject gem = Instantiate(garnetPrefab);
            gem.transform.position = position;

            GameObject whip = Instantiate(whipTailPrefab);
            position.y += 2f;
            whip.transform.position = position;
        }
        
    }
}
