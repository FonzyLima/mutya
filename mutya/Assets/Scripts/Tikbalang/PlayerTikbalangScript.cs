using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTikbalangScript : MonoBehaviour{
    private InventoryManager invManager;
    public TeleportScene TPScene;

    public GameObject attackText;
    public GameObject tikbalang;
    private Transform tikbalangPos;

    private Vector2 currentPos; 

    public float attackDistance;   
    private bool isDestroyed;
    public GameObject jadePrefab;

    private TikbalangAI tScript;

    public AudioClip whipSFX;

    public PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        attackText.gameObject.SetActive(false);
        invManager = GetComponent<InventoryManager>();
        tScript = tikbalang.GetComponent<TikbalangAI>();

        tikbalangPos = tikbalang.GetComponent<Transform>(); // position of tikbalang
        currentPos = GetComponent<Transform>().position; // position of player
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDestroyed && !tScript.found && invManager.tikbalang_item >= 1f && Vector2.Distance(transform.position, tikbalangPos.position) < attackDistance){
            attackText.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F)){
                AudioSource.PlayClipAtPoint(whipSFX, transform.position);

                TPScene.addBossBeaten();
                Vector3 position = tikbalang.transform.position;
                Destroy(tikbalang);
                isDestroyed = true;
                GameObject jade = Instantiate(jadePrefab);
                jade.transform.position = position;
            }
        }
        else{
            attackText.gameObject.SetActive(false);
        }
    }
}
