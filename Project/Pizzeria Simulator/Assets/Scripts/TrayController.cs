using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayController : MonoBehaviour
{
    private bool isPizzaOnTray = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pizza"))
        {
            Debug.Log("Pizza was detected");
            isPizzaOnTray = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pizza"))
        {
            Debug.Log("Pizza is no longer detected");
            isPizzaOnTray = false;
        }
    }

    public bool GetIsPizzaOnTray()
    {
        return isPizzaOnTray;
    }

    public void GetParentTag()
    {
        string parentTag = transform.parent.tag;
        Debug.Log("Parent tag: " + parentTag);
    }
}
