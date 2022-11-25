using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookFlipper : MonoBehaviour
{
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.Play("Base Layer.FlipNext");
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.Play("Base Layer.FlipPrev");
        }
    }
}
