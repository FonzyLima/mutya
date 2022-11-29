using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWaves : MonoBehaviour
{
    public BakunawaSceneMovement playerMovement;
    public GameObject soundWaves;
    public GameObject player;
    Vector2 mousePos;
    public AudioSource bangSFX;
    public Camera cam;
    public float angle;
    public Vector2 lookDir;
    // Update is called once per frame
    public Rigidbody2D rbWave;
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0)){
            
            soundWaves.transform.position = new Vector3(player.transform.position.x+9.5f,player.transform.position.y+-3.4f,0);
            soundWaves.SetActive(true);
            playerMovement.canMove = false;
            bangSFX.Play();
            StartCoroutine(waveTime());
        }
            
    }
    void FixedUpdate()
    {
        lookDir = mousePos - playerMovement.rb.position;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        print(angle);
        
    }
    public IEnumerator waveTime(){
        yield return new WaitForSeconds(1f);
        soundWaves.SetActive(false);
        playerMovement.canMove = true;
    }
}
