using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPanel : MonoBehaviour
{
    public GameObject exitPanel;

    void Start()
    {
        exitPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exitPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void ExitGameButton()
    {
        Debug.Log("Exit button clicked");
        Application.Quit();
    }

    public void CancelExitButton()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        exitPanel.SetActive(false);
        Debug.Log("Cancel button clicked");
    }
}
