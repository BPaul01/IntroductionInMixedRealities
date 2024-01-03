using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenController : MonoBehaviour
{
    private Animator animator;
    private bool doorOpen = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !doorOpen)
        {
            animator.SetBool("DoorOpen", !animator.GetBool("DoorOpen"));
            doorOpen = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && doorOpen)
        {
            animator.SetBool("DoorClose", !animator.GetBool("DoorClose"));
            doorOpen = false;
        }
    }
}