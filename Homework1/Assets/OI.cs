using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OI : MonoBehaviour
{
    public float attackRange = 0.25f;
    public GameObject ImageTarget;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Check the distance between the two objects
        float distance = Vector3.Distance(transform.position, ImageTarget.transform.position);

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // If the distance is within the attack range, trigger the attack animation
        if (distance < attackRange)
        {
            if (stateInfo.IsName("idle"))
            {
                animator.SetTrigger("StartAttackOI");
            }
        }
        else
        {
            if (stateInfo.IsName("run_forward"))
            {
                animator.SetTrigger("StopAttackOI");
            }
        }
    }
}
