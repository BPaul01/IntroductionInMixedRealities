using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private bool isPizzaOnTray = false;
    private UIBellController uiBellController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pizza"))
        {
            Debug.Log("Pizza was detected on the evaluation tray");
            isPizzaOnTray = true;

            //Start checking the pizza
            string currentRecipe = uiBellController.GetCurrentRecipe();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pizza"))
        {
            Debug.Log("Pizza is no longer detected on the evaluation tray");
            isPizzaOnTray = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //aquire the UIBellController instance

        // Find the first instance of UIBellController in the scene
        uiBellController = Object.FindObjectOfType<UIBellController>();

        // Check if the GameObject was found
        if (uiBellController != null)
        {
            Debug.Log("UIBellController aqured");
        }
        else
        {
            Debug.LogError("UIBellController could not be aquired");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
