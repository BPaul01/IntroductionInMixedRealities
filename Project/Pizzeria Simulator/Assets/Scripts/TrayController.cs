using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayController : MonoBehaviour
{
    public Transform arrowTransform;

    public GameObject greenArrow;
    public GameObject redArrow;

    private AudioSource sound;
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

    public string GetParentTag()
    {
        string parentTag = transform.parent.tag;
        //Debug.Log("Parent tag: " + parentTag);
        return parentTag;
    }

    public AudioSource GetAudioSourceDonePizza()
    {
        sound = GetComponents<AudioSource>()[0];
        return sound;
    }

    public AudioSource GetAudioSourceBurntPizza()
    {
        sound = GetComponents<AudioSource>()[1];
        return sound;
    }

    public Transform GetReferenceArrow()
    {
        return arrowTransform;
    }

    public GameObject GetRedArrowObject()
    {
        return redArrow;
    }

    public GameObject GetGreenArrowObject()
    {
        return greenArrow;
    }


}
