using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animIdle : MonoBehaviour
{
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1") && anim.GetCurrentAnimatorStateInfo(0).IsName("Any State"))
            anim.Play("Idle");
     }
}
