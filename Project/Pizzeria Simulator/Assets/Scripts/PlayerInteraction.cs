using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Transform handTransform;
    private GameObject heldObject;
    public GameObject oliveToSpawn;
    public GameObject pepperoniToSpawm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            TryPickupObject();
        }
    }

    void TryPickupObject()
    {
        // Create a ray from the camera to the cursor position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Check if the ray hits an object
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            // Get the GameObject that was hit
            GameObject hitObject = hit.collider.gameObject;

            // Check if the object is a bowl
            if (hitObject.CompareTag("OlivesBowl"))
            {
                // Spawn an object in the hand (you can instantiate your object here)
                if (heldObject == null)
                {
                    heldObject = Instantiate(oliveToSpawn, handTransform.position, handTransform.rotation, handTransform);
                }
            }
            if (hitObject.CompareTag("PepperoniBowl"))
            {
                // Spawn an object in the hand (you can instantiate your object here)
                if (heldObject == null)
                {
                    heldObject = Instantiate(pepperoniToSpawm, handTransform.position, handTransform.rotation, handTransform);
                }
            }
        }
    }
}
