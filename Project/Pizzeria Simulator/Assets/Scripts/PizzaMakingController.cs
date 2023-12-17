using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaMakingController : MonoBehaviour
{
    public Transform handTransform;
    public List<Transform> toppings;
    //public Transform topping2;

    public GameObject oliveToSpawn;
    public GameObject pepperoniToSpawn;
    public GameObject cornToSpawn;
    public GameObject baconToSpawn;
    public GameObject chickenToSpawn;
    public GameObject pepperToSpawn;
    public GameObject meatToSpawn;
    public GameObject bluecheeseToSpawn;
    public GameObject onionToSpawn;
    public GameObject mozzarellaToSpawn;
    public GameObject mushroomToSpawn;
    public GameObject tomatoToSpawn;
    public GameObject hamToSpawn;
    public GameObject cheesesliceToSpawn;
    public GameObject hotpepperToSpawn;
    public GameObject redpepperToSpawn;

    public GameObject pepperoniTopping;
    public GameObject oliveTopping;

    private GameObject heldObject;
    private GameObject top1;
    private GameObject top2;

    private int[] toppingsAparitii;

    void Start()
    {
        toppingsAparitii = new int[toppings.Count];
    }

    // Update is called once per frame
    void Update()
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
            if (hitObject.CompareTag("OlivesBowl") || hitObject.CompareTag("PepperoniBowl")
                || hitObject.CompareTag("CornBowl") || hitObject.CompareTag("BaconBowl")
                || hitObject.CompareTag("ChickenBowl") || hitObject.CompareTag("PepperBowl")
                || hitObject.CompareTag("MeatBowl") || hitObject.CompareTag("BluecheeseBowl")
                || hitObject.CompareTag("OnionBowl") || hitObject.CompareTag("MozzarellaBowl")
                || hitObject.CompareTag("MushroomBowl") || hitObject.CompareTag("TomatoBowl")
                || hitObject.CompareTag("HamBowl") || hitObject.CompareTag("CheesesliceBowl")
                || hitObject.CompareTag("HotpepperBowl") || hitObject.CompareTag("RedpepperBowl"))
            {
                // Spawn an object in the hand (you can instantiate your object here)
                if (heldObject == null && Input.GetKeyDown(KeyCode.G))
                {
                    if (hitObject.CompareTag("OlivesBowl"))
                    {
                        heldObject = Instantiate(oliveToSpawn, handTransform.position, handTransform.rotation, handTransform);
                        heldObject.tag = "Olive";
                    }
                    else if (hitObject.CompareTag("PepperoniBowl"))
                    {
                        heldObject = Instantiate(pepperoniToSpawn, handTransform.position, handTransform.rotation, handTransform);
                        heldObject.tag = "Pepperoni";
                    }
                    else if (hitObject.CompareTag("CornBowl"))
                    {
                        heldObject = Instantiate(cornToSpawn, handTransform.position, handTransform.rotation, handTransform);
                        heldObject.tag = "Corn";
                    }
                    else if (hitObject.CompareTag("BaconBowl"))
                    {
                        heldObject = Instantiate(baconToSpawn, handTransform.position, handTransform.rotation, handTransform);
                        heldObject.tag = "Bacon";
                    }
                    else if (hitObject.CompareTag("ChickenBowl"))
                    {
                        heldObject = Instantiate(chickenToSpawn, handTransform.position, handTransform.rotation, handTransform);
                        heldObject.tag = "Chicken";
                    }
                    else if (hitObject.CompareTag("PepperBowl"))
                    {
                        heldObject = Instantiate(pepperToSpawn, handTransform.position, handTransform.rotation, handTransform);
                        heldObject.tag = "Pepper";
                    }
                    else if (hitObject.CompareTag("MeatBowl"))
                    {
                        heldObject = Instantiate(meatToSpawn, handTransform.position, handTransform.rotation, handTransform);
                        heldObject.tag = "Meat";
                    }
                    else if (hitObject.CompareTag("BluecheeseBowl"))
                    {
                        heldObject = Instantiate(bluecheeseToSpawn, handTransform.position, handTransform.rotation, handTransform);
                        heldObject.tag = "BlueCheese";
                    }
                    else if (hitObject.CompareTag("OnionBowl"))
                    {
                        heldObject = Instantiate(onionToSpawn, handTransform.position, handTransform.rotation, handTransform);
                        heldObject.tag = "Onion";

                    }
                    else if (hitObject.CompareTag("MozzarellaBowl"))
                    {
                        heldObject = Instantiate(mozzarellaToSpawn, handTransform.position, handTransform.rotation, handTransform);
                        heldObject.tag = "Mozzarella";
                    }
                    else if (hitObject.CompareTag("MushroomBowl"))
                    {
                        heldObject = Instantiate(mushroomToSpawn, handTransform.position, handTransform.rotation, handTransform);
                        heldObject.tag = "Mushroom";
                    }
                    else if (hitObject.CompareTag("TomatoBowl"))
                    {
                        heldObject = Instantiate(tomatoToSpawn, handTransform.position, handTransform.rotation, handTransform);
                        heldObject.tag = "Tomato";
                    }
                    else if (hitObject.CompareTag("HamBowl"))
                    {
                        heldObject = Instantiate(hamToSpawn, handTransform.position, handTransform.rotation, handTransform);
                        heldObject.tag = "Ham";
                    }
                    else if (hitObject.CompareTag("CheesesliceBowl"))
                    {
                        heldObject = Instantiate(cheesesliceToSpawn, handTransform.position, handTransform.rotation, handTransform);
                        heldObject.tag = "CheeseSlice";

                    }
                    else if (hitObject.CompareTag("HotpepperBowl"))
                    {
                        heldObject = Instantiate(hotpepperToSpawn, handTransform.position, handTransform.rotation, handTransform);
                        heldObject.tag = "HotPepper";
                    }
                    else if (hitObject.CompareTag("RedpepperBowl"))
                    {
                        heldObject = Instantiate(redpepperToSpawn, handTransform.position, handTransform.rotation, handTransform);
                        heldObject.tag = "RedPepper";
                    }

                }
                else if (heldObject != null && Input.GetKeyDown(KeyCode.G))
                {
                    if (hitObject.CompareTag("OlivesBowl") && heldObject != oliveToSpawn)
                    {
                        // Distrugem obiectul curent
                        Destroy(heldObject);

                        // Instantiem un nou obiect cu ingredientul potrivit
                        heldObject = Instantiate(oliveToSpawn, handTransform.position, handTransform.rotation, handTransform);
                    }
                    if (hitObject.CompareTag("PepperoniBowl") && heldObject != pepperoniToSpawn)
                    {
                        Destroy(heldObject);

                        heldObject = Instantiate(pepperoniToSpawn, handTransform.position, handTransform.rotation, handTransform);
                    }
                    if (hitObject.CompareTag("CornBowl") && heldObject != cornToSpawn)
                    {
                        Destroy(heldObject);

                        heldObject = Instantiate(cornToSpawn, handTransform.position, handTransform.rotation, handTransform);
                    }
                    if (hitObject.CompareTag("BaconBowl") && heldObject != baconToSpawn)
                    {
                        Destroy(heldObject);

                        heldObject = Instantiate(baconToSpawn, handTransform.position, handTransform.rotation, handTransform);
                    }
                    if (hitObject.CompareTag("ChickenBowl") && heldObject != chickenToSpawn)
                    {
                        Destroy(heldObject);

                        heldObject = Instantiate(chickenToSpawn, handTransform.position, handTransform.rotation, handTransform);
                    }
                    if (hitObject.CompareTag("PepperBowl") && heldObject != pepperToSpawn)
                    {
                        Destroy(heldObject);

                        heldObject = Instantiate(pepperToSpawn, handTransform.position, handTransform.rotation, handTransform);
                    }
                    if (hitObject.CompareTag("MeatBowl") && heldObject != meatToSpawn)
                    {
                        Destroy(heldObject);

                        heldObject = Instantiate(meatToSpawn, handTransform.position, handTransform.rotation, handTransform);
                    }
                    if (hitObject.CompareTag("BluecheeseBowl") && heldObject != bluecheeseToSpawn)
                    {
                        Destroy(heldObject);

                        heldObject = Instantiate(bluecheeseToSpawn, handTransform.position, handTransform.rotation, handTransform);
                    }
                    if (hitObject.CompareTag("OnionBowl") && heldObject != onionToSpawn)
                    {
                        Destroy(heldObject);

                        heldObject = Instantiate(onionToSpawn, handTransform.position, handTransform.rotation, handTransform);
                    }
                    if (hitObject.CompareTag("MozzarellaBowl") && heldObject != mozzarellaToSpawn)
                    {
                        Destroy(heldObject);

                        heldObject = Instantiate(mozzarellaToSpawn, handTransform.position, handTransform.rotation, handTransform);
                    }
                    if (hitObject.CompareTag("MushroomBowl") && heldObject != mushroomToSpawn)
                    {
                        Destroy(heldObject);

                        heldObject = Instantiate(mushroomToSpawn, handTransform.position, handTransform.rotation, handTransform);
                    }
                    if (hitObject.CompareTag("TomatoBowl") && heldObject != tomatoToSpawn)
                    {
                        Destroy(heldObject);

                        heldObject = Instantiate(tomatoToSpawn, handTransform.position, handTransform.rotation, handTransform);
                    }
                    if (hitObject.CompareTag("HamBowl") && heldObject != hamToSpawn)
                    {
                        Destroy(heldObject);

                        heldObject = Instantiate(hamToSpawn, handTransform.position, handTransform.rotation, handTransform);
                    }
                    if (hitObject.CompareTag("CheesesliceBowl") && heldObject != cheesesliceToSpawn)
                    {
                        Destroy(heldObject);

                        heldObject = Instantiate(cheesesliceToSpawn, handTransform.position, handTransform.rotation, handTransform);
                    }
                    if (hitObject.CompareTag("HotpepperBowl") && heldObject != hotpepperToSpawn)
                    {
                        Destroy(heldObject);

                        heldObject = Instantiate(hotpepperToSpawn, handTransform.position, handTransform.rotation, handTransform);
                    }
                    if (hitObject.CompareTag("RedpepperBowl") && heldObject != redpepperToSpawn)
                    {
                        Destroy(heldObject);

                        heldObject = Instantiate(redpepperToSpawn, handTransform.position, handTransform.rotation, handTransform);
                    }
                }
            }

            //Pizza making part
            if (hitObject.CompareTag("Pizza") && heldObject != null && Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Pizza area");

                int poz = -1;
                bool gasit = false;
                //find the next empty topping
                for (int i = 0; i < toppings.Count; i++)
                {
                    if (toppingsAparitii[i] == 0 && gasit == false)
                    {
                        poz = i;
                        gasit = true;
                        toppingsAparitii[i] = 1; 
                    }
                }

                Debug.Log("Empty topping index: " + poz);

                if (poz >= 0)
                {
                    if (heldObject.CompareTag("Pepperoni"))
                    {
                        Destroy(heldObject);
                        Instantiate(pepperoniTopping, toppings[poz].position, toppings[poz].rotation, toppings[poz]);
                    }
                    else if(heldObject.CompareTag("Olive"))
                    {
                        Destroy(heldObject);
                        Instantiate(oliveTopping, toppings[poz].position, toppings[poz].rotation, toppings[poz]);
                    }
                }
                
            }
        }

        // Check if the object is held and the X key is pressed
        if (heldObject != null && Input.GetKeyDown(KeyCode.X))
        {
            // Destroy the held object
            Destroy(heldObject);

            // Set heldObject to null to indicate that nothing is being held
            heldObject = null;
        }
    }
}
