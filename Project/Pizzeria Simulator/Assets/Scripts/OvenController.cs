using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Change this to your desired input
        {
            animator.SetBool("DoorOpen", !animator.GetBool("DoorOpen"));
        }
    }
}

