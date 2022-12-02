using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInd : MonoBehaviour
{
    private UnityEngine.Rendering.Universal.Light2D light;
    private Transform player;
    public float visibleDist = 5f;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        light = gameObject.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if(distance > visibleDist){
            light.pointLightOuterRadius = 0f;
        }
        else if(distance <= 0.2){
            light.pointLightOuterRadius = 0.2f;
        }
        else{
            light.pointLightOuterRadius = 1f/distance * 1.5f;
        }

    }
}
