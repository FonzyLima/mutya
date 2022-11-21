using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipMechanic : MonoBehaviour
{
    public Transform whipPoint;
    public GameObject whipPrefab;

    public float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject whip = Instantiate(whipPrefab, whipPoint.position, whipPoint.rotation);
        Rigidbody2D rb = whip.GetComponent<Rigidbody2D>();
        rb.AddForce(whipPoint.up * bulletForce, ForceMode2D.Impulse);
    }

}
