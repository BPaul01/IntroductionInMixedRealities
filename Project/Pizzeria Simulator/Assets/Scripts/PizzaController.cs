using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaController : MonoBehaviour
{
    private TrayController trayController;
    private PlayerInteraction playerInteraction;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("In PizzaController");
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has the TrayController script
        trayController = other.GetComponent<TrayController>();

        if (trayController != null)
        {
            // Access the TrayController instance and perform actions
            trayController.GetParentTag();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("OvenTray"))
        {
            Debug.Log("Refference to TrayController instance removed");
            trayController = null;
        }
    }


    // Update is called once per frame
    void Update()
    {
        /*
         * Access TrayController and PlayerInteraction
         * Check to see if the pizza is on the tray and the oven door of the same oven is shut
         * If so, start the cooking proccess
         */

    }
}
