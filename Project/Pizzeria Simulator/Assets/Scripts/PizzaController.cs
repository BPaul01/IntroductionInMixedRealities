using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaController : MonoBehaviour
{
    private List<Material> cookingStages = new List<Material>(); // Assign materials for different cooking stages
    private static float totalCookingTime = 31.0f; // Total cooking time in seconds
    private static float stageTimePeriod = 10.0f;
    private float elapsedTime = 0.0f;
    private int currentStageIndex = 0;
    private TrayController trayController;
    private PlayerInteraction playerInteraction;
    private bool donePizza = false;
    private bool burntPizza = false;

    private Transform arrowTrayTransform;
    private GameObject greenArrowToSpawn;
    private GameObject redArrowToSpawn;
    private GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Loading materials for the pizza");

        //Raw
        Material material = Resources.Load<Material>("PizzaCookingStages/Raw");
        if (material != null)
        {
            cookingStages.Add(material);
            Debug.Log("Loaded Raw material");
        }

        //SemiCooked
        material = Resources.Load<Material>("PizzaCookingStages/SemiCooked");
        if (material != null)
        {
            cookingStages.Add(material);
            Debug.Log("Loaded SemiCooked material");
        }

        //Cooked
        material = Resources.Load<Material>("PizzaCookingStages/Cooked");
        if (material != null)
        {
            cookingStages.Add(material);
            Debug.Log("Loaded Cooked material");
        }

        //Burnt
        material = Resources.Load<Material>("PizzaCookingStages/Burnt");
        if (material != null)
        {
            cookingStages.Add(material);
            Debug.Log("Loaded Burnt material");
        }

        Debug.Log("Nr of materials loaded: " + cookingStages.Count);
    }

    private void ApplyMaterialToParts(int index)
    {
        // Assuming the parts you want to apply the material to have MeshRenderer components
        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();

        if (meshRenderers.Length > 0)
        {
            foreach (MeshRenderer renderer in meshRenderers)
            {
                // Check if the current child's name is "Circle" or "Torus"
                if (renderer.gameObject.name == "Circle" || renderer.gameObject.name == "Torus")
                {
                    renderer.material = cookingStages[index]; // Change the index based on the material you want to apply
                }
            }
        }
        else
        {
            Debug.LogError("No MeshRenderers found in the prefab parts.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OvenTray"))
        {
            // Check if the collided object has the TrayController script
            trayController = other.GetComponent<TrayController>();
            

            if (trayController != null)
            {
                // Access the TrayController instance and perform actions
                trayController.GetParentTag();

                Debug.Log("Trying to load arrow objects");

                arrowTrayTransform = trayController.GetReferenceArrow();
                redArrowToSpawn = trayController.GetRedArrowObject();
                greenArrowToSpawn = trayController.GetGreenArrowObject();
                
                if(redArrowToSpawn != null && greenArrowToSpawn != null && arrowTrayTransform != null)
                {
                    Debug.Log("Loaded objects succesfully");
                    
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("OvenTray"))
        {
            //Debug.Log("Refference to TrayController instance removed");
            trayController = null;

            arrowTrayTransform = null;
            if(arrow != null)
            {
                Destroy(arrow);
            }
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
                    //Start the cooking process
                    Debug.Log("Cooking proccess can begin in the Oven1");
                    CookPizza();
                }
                else if(oven == "Oven2" && !playerInteraction.GetOven2DoorOpen())
                {
                    //Start the cooking process
                    Debug.Log("Cooking proccess can begin in the Oven2");
                    CookPizza();
                }
            }
        }
    }

    // Method to handle the cooking process
    private void CookPizza()
    {
        // Increment elapsed time
        elapsedTime += Time.deltaTime;

        // Check if the total cooking time has not been reached
        if (elapsedTime < totalCookingTime)
        {
            // Check if it's time to switch to the next cooking stage
            if (elapsedTime >= stageTimePeriod * (currentStageIndex + 1))
            {
                // Increment the stage index
                currentStageIndex = Mathf.Min(currentStageIndex + 1, cookingStages.Count - 1);

                // Apply the material for the current stage
                ApplyMaterialToParts(currentStageIndex);
            }

            if (currentStageIndex == 2 && !donePizza)
            {
                AudioSource audioSource1 = trayController.GetAudioSourceDonePizza();
                audioSource1.Play();

                Destroy(arrow);

                if (arrowTrayTransform != null && greenArrowToSpawn != null)
                {
                    Debug.Log("Spawning green arrow");
                    arrow = Instantiate(greenArrowToSpawn, arrowTrayTransform.position, arrowTrayTransform.rotation, arrowTrayTransform);
                }

                donePizza = true;
            }

            if(currentStageIndex == 3 && donePizza && !burntPizza)
            {
                AudioSource audioSource2 = trayController.GetAudioSourceBurntPizza();
                audioSource2.Play();

                Destroy(arrow);

                if (arrowTrayTransform != null && redArrowToSpawn != null)
                {
                    Debug.Log("Spawning red arrow");
                    arrow = Instantiate(redArrowToSpawn, arrowTrayTransform.position, arrowTrayTransform.rotation, arrowTrayTransform);
                }

                burntPizza = true;
            }
        }
        else
        {
            // Cooking process is complete, handle accordingly
            Debug.Log("Pizza is fully cooked!");
        }
    }
}
