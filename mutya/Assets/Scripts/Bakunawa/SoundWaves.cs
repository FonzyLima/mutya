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

    public bool Pause = false;

    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        //heres the clicking thing

        if (!Pause)
        {
            if (Input.GetMouseButtonDown(0)){
                // soundWaves.transform.position = new Vector3(player.transform.position.x+9.5f,player.transform.position.y+-3.4f,0);
                soundWaves.SetActive(true);
                playerMovement.canMove = false;
                bangSFX.Play();
                StartCoroutine(waveTime());
            }
        }

        
            
    }
    void FixedUpdate()
    {
        //itoy wala pang ginagawa hahahha
        lookDir = mousePos - playerMovement.rb.position;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        if(angle >= -45 && angle < 45){
            angle = 0;
            soundWaves.transform.position = new Vector3(player.transform.position.x + 10.95f, player.transform.position.y - 3.51f, 0);
        }
        else if(angle >= 45 && angle < 145){
            angle = 90;
            soundWaves.transform.position = new Vector3(player.transform.position.x + 3.51f, player.transform.position.y + 10.51f, 0);
        }
        else if((angle >= 145 && angle <= 180) || (angle >= -180 && angle <= -145)){
            angle = 179;
            soundWaves.transform.position = new Vector3(player.transform.position.x - 10.25f, player.transform.position.y + 3.4f, 0);
        }
        else{
            angle = -90;
            soundWaves.transform.position = new Vector3(player.transform.position.x - 3.51f, player.transform.position.y - 10.51f, 0);
        }
        rbWave.rotation = angle;
        
    }
    public IEnumerator waveTime(){
        yield return new WaitForSeconds(1f);
        soundWaves.SetActive(false);
        playerMovement.canMove = true;
    }

    public void pauseSound (bool val)
    {
        Pause = val;
    }
}
