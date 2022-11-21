using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManananggalMechanic : MonoBehaviour
{

    public PlayerMovement playerMovement;
    Vector2 mousePos;

    public Camera cam;

    public Transform whipPoint;
    public GameObject whipPrefab;

    public float bulletForce = 20f;
    public float angle;
    public Vector2 lookDir;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        lookDir = mousePos - playerMovement.rb.position;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        // playerMovement.rb.rotation = angle;
    }

    void Shoot()
    {
        GameObject whip = Instantiate(whipPrefab, whipPoint.position, whipPoint.rotation);
        Rigidbody2D rb = whip.GetComponent<Rigidbody2D>();
        rb.rotation = angle;
        rb.AddForce(lookDir * bulletForce, ForceMode2D.Impulse);
    }
}
