using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookFlipper : MonoBehaviour
{
    public Animator animator;
    public int pageCounter = 1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && pageCounter < 10)
        {
            animator.Play("Base Layer.FlipNext");
            pageCounter++;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && pageCounter > 1)
        {
            animator.Play("Base Layer.FlipPrev");
            pageCounter--;
        }
    }
}
