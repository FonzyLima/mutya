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
            StartCoroutine(NextPage());   
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StartCoroutine(PrevPage());   
        }
    }

    IEnumerator NextPage()
    {
        animator.SetBool("flipNext", true);
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("flipNext", false);
    }

    IEnumerator PrevPage()
    {
        animator.SetBool("flipPrev", true);
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("flipPrev", false);
    }
}
