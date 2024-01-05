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
            //Debug.Log("Refference to TrayController instance removed");
            trayController = null;
        }
    }

    public void SetPlayerInteractionInstance(PlayerInteraction playerInteraction)
    {
        this.playerInteraction = playerInteraction;
        //Debug.Log("Instance of PlayerInteraction aquired");
    }


    // Update is called once per frame
    void Update()
    {
        /*
         * Access TrayController and PlayerInteraction
         * Check to see if the pizza is on the tray and the oven door of the same oven is shut
         * If so, start the cooking proccess
         */
        
        if (trayController != null && playerInteraction != null)
        {
            if (trayController.GetIsPizzaOnTray())
            {
                //Get the tag of the oven
                string oven = trayController.GetParentTag();
                //Debug.Log(playerInteraction.GetOven1DoorOpen());
                if (oven == "Oven1" && !playerInteraction.GetOven1DoorOpen())
                {
                    Debug.Log("Cooking proccess can begin in the Oven1");
                    //Start the cooking process
                }
                else if(oven == "Oven2" && !playerInteraction.GetOven2DoorOpen())
                {
                    Debug.Log("Cooking proccess can begin in the Oven2");
                    //Start the cooking process
                }
            }
        }
    }
}
