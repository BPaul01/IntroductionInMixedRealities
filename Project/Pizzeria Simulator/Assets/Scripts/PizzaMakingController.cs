using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaMakingController : MonoBehaviour
{
    public Transform handTransform;
    public Transform pizzaTransform;
    public Transform doughTransform;


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
    public GameObject tomatoladleToSpawn;
    public GameObject cheeseladleToSpawn;
    public GameObject pizzaDoughToSpawn;

    public GameObject pepperoniTopping;
    public GameObject oliveTopping;
    public GameObject cornTopping;
    public GameObject baconTopping;
    public GameObject chickenTopping;
    public GameObject pepperTopping;
    public GameObject meatTopping;
    public GameObject bluecheeseTopping;
    public GameObject onionTopping;
    public GameObject mozzarellaTopping;
    public GameObject mushroomTopping;
    public GameObject tomatoTopping;
    public GameObject hamTopping;
    public GameObject cheesesliceTopping;
    public GameObject redpepperTopping;
    public GameObject hotpepperTopping;
    public GameObject tomatosouceTopping;
    public GameObject cheesesouceTopping;

    private GameObject pizzaDough;
    private GameObject heldObject;
    private bool holdingObject = false;

    //private int[] toppingsAparitii;
    //private List<Transform> toppings;

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
                || hitObject.CompareTag("HotpepperBowl") || hitObject.CompareTag("RedpepperBowl")
                || hitObject.CompareTag("TomatoSouceBowl") || hitObject.CompareTag("CheeseSouceBowl"))
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
                    else if (hitObject.CompareTag("TomatoSouceBowl"))
                    {
                        heldObject = Instantiate(tomatoladleToSpawn, handTransform.position, handTransform.rotation, handTransform);
                        heldObject.tag = "TomatoLadle";
                    }
                    else if (hitObject.CompareTag("CheeseSouceBowl"))
                    {
                        heldObject = Instantiate(cheeseladleToSpawn, handTransform.position, handTransform.rotation, handTransform);
                        heldObject.tag = "CheeseLadle";
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
                    if (hitObject.CompareTag("TomatoSouceBowl"))
                    {
                        Destroy(heldObject);
                        heldObject = Instantiate(tomatoladleToSpawn, handTransform.position, handTransform.rotation, handTransform);
                    }
                    if (hitObject.CompareTag("CheeseSouceBowl"))
                    {
                        Destroy(heldObject);
                        heldObject = Instantiate(cheeseladleToSpawn, handTransform.position, handTransform.rotation, handTransform);
                    }
                }
            }

            //Pizza dough spawn
            if (hitObject.CompareTag("DoughBowl") && Input.GetKeyDown(KeyCode.G))
            {
                Debug.Log("Dough area");

                pizzaDough = Instantiate(pizzaDoughToSpawn, doughTransform.position, doughTransform.rotation, doughTransform);

            }

            //Pizza making part
            if (hitObject.CompareTag("Pizza") && heldObject != null && Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Pizza area");
                /*
                 * TODO:
                 *  1. Search for a topping refference of the pizza that has no children (aka is empty)
                 *  2. The result should be a transform component of the first empty topping reference
                 *  3. replace child with the result 
                 *  4. delete 
                 */

                //Get all the childern
                bool found = false;
                int childCount = hitObject.transform.childCount;
                Transform child = null;
                int poz = -1;
                if (childCount > 0)
                {
                    for (int i = 0; i < childCount; i++)
                    {
                        //get the child
                        child = hitObject.transform.GetChild(i);

                        //verify if the object has any children
                        if (child.childCount == 0 && child.name.StartsWith("Top"))
                        {
                            found = true;
                            poz = i - 2;
                            break;
                        }
                    }
                }

                if (found)
                {
                    Quaternion randomRotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);

                    Debug.Log("Empty topping:" + child.gameObject.name);

                    if (heldObject.CompareTag("TomatoLadle") && poz <= 1)
                    {
                        Destroy(heldObject);
                        Instantiate(tomatosouceTopping, child.position, Quaternion.Euler(90f, 0f, 0f), child);
                    }
                    else if (heldObject.CompareTag("CheeseLadle") && poz <= 1)
                    {
                        Destroy(heldObject);
                        Instantiate(cheesesouceTopping, child.position, Quaternion.Euler(90f, 0f, 0f), child);
                    }

                    else if (heldObject.CompareTag("Pepperoni"))
                    {
                        Destroy(heldObject);
                        Instantiate(pepperoniTopping, child.position, randomRotation, child);
                    }
                    else if (heldObject.CompareTag("Olive"))
                    {
                        Destroy(heldObject);
                        Instantiate(oliveTopping, child.position, randomRotation, child);
                    }
                    else if (heldObject.CompareTag("Corn"))
                    {
                        Destroy(heldObject);
                        Instantiate(cornTopping, child.position, randomRotation, child);
                    }
                    else if (heldObject.CompareTag("Bacon"))
                    {
                        Destroy(heldObject);
                        Instantiate(baconTopping, child.position, randomRotation, child);
                    }
                    else if (heldObject.CompareTag("Chicken"))
                    {
                        Destroy(heldObject);
                        Instantiate(chickenTopping, child.position, randomRotation, child);
                    }
                    else if (heldObject.CompareTag("Pepper"))
                    {
                        Destroy(heldObject);
                        Instantiate(pepperTopping, child.position, randomRotation, child);
                    }
                    else if (heldObject.CompareTag("Meat"))
                    {
                        Destroy(heldObject);
                        Instantiate(meatTopping, child.position, randomRotation, child);
                    }
                    else if (heldObject.CompareTag("BlueCheese"))
                    {
                        Destroy(heldObject);
                        Instantiate(bluecheeseTopping, child.position, randomRotation, child);
                    }
                    else if (heldObject.CompareTag("Onion"))
                    {
                        Destroy(heldObject);
                        Instantiate(onionTopping, child.position, randomRotation, child);
                    }
                    else if (heldObject.CompareTag("Mozzarella"))
                    {
                        Destroy(heldObject);
                        Instantiate(mozzarellaTopping, child.position, randomRotation, child);
                    }
                    else if (heldObject.CompareTag("Mushroom"))
                    {
                        Destroy(heldObject);
                        Instantiate(mushroomTopping, child.position, randomRotation, child);
                    }
                    else if (heldObject.CompareTag("Tomato"))
                    {
                        Destroy(heldObject);
                        Instantiate(tomatoTopping, child.position, randomRotation, child);
                    }
                    else if (heldObject.CompareTag("Ham"))
                    {
                        Destroy(heldObject);
                        Instantiate(hamTopping, child.position, randomRotation, child);

                    }
                    else if (heldObject.CompareTag("CheeseSlice"))
                    {
                        Destroy(heldObject);
                        Instantiate(cheesesliceTopping, child.position, randomRotation, child);

                    }
                    else if (heldObject.CompareTag("RedPepper"))
                    {
                        Destroy(heldObject);
                        Instantiate(redpepperTopping, child.position, randomRotation, child);

                    }
                    else if (heldObject.CompareTag("HotPepper"))
                    {
                        Destroy(heldObject);
                        Instantiate(hotpepperTopping, child.position, randomRotation, child);

                    }
                }
                else
                    Debug.Log("Pizza is full");

            }

            //Pizza holding part
            if (hitObject.CompareTag("Pizza") && !holdingObject && Input.GetKeyDown(KeyCode.G))
            {
                if (heldObject != null)
                {
                    Destroy(heldObject);
                }
                Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
                heldObject = hit.collider.gameObject;
                GrabObject(rb);
                heldObject.tag = "HeldPizza";
            }
            else if (holdingObject && heldObject.CompareTag("HeldPizza") && Input.GetKeyDown(KeyCode.G))
            {
                if (heldObject != null)
                {
                    Rigidbody rb = pizzaTransform.GetChild(0).GetComponent<Rigidbody>();
                    ReleaseObject(rb);
                    heldObject.tag = "Pizza";
                    heldObject = null;
                }
            }
        }

        // Check if the object is held and the X key is pressed
        if (heldObject != null && Input.GetKeyDown(KeyCode.X))
        {
            // Destroy the held object
            Destroy(heldObject);

            holdingObject = false;

            // Set heldObject to null to indicate that nothing is being held
            heldObject = null;
        }
    }

    private void GrabObject(Rigidbody rb)
    {
        Debug.Log("Trying to grab the pizza");

        holdingObject = true;

        // Disable physics interactions temporarily
        rb.isKinematic = true;

        // Move the object to the player's position
        //rb.transform.position = transform.position;

        // Attach the object to the player
        rb.transform.parent = pizzaTransform;

        //rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    private void ReleaseObject(Rigidbody rb)
    {
        Debug.Log("Trying to release the pizza");

        holdingObject = false;

        // Enable physics interactions
        rb.isKinematic = false;

        // Dettach the object to the player
        rb.transform.parent = null;

        // Set the velocity to zero to prevent unexpected movements
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
