using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    public Material highlightMaterial; // Assign your highlight material in the inspector

    private GameObject highlightedBowl;
    private Dictionary<GameObject, Dictionary<Renderer, Material>> originalMaterialsDict = new Dictionary<GameObject, Dictionary<Renderer, Material>>();

    // Update is called once per frame
    void Update()
    {
        // Move this outside the condition to handle cases where no object is hit
        ResetHighlight();

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
                || hitObject.CompareTag("TomatoSouceBowl") || hitObject.CompareTag("CheeseSouceBowl")
                || hitObject.CompareTag("DoughBowl"))
            {
                // Highlight the bowl
                HighlightBowl(hitObject);
            }

        }
    }

    void HighlightBowl(GameObject bowl)
    {
        // Store the original materials
        Renderer[] childRenderers = bowl.GetComponentsInChildren<Renderer>();
        Dictionary<Renderer, Material> originalMaterials = new Dictionary<Renderer, Material>();

        foreach (Renderer childRenderer in childRenderers)
        {
            originalMaterials[childRenderer] = childRenderer.material;
        }

        // Store the original materials for later reset
        originalMaterialsDict[bowl] = originalMaterials;

        // Assign the highlight material to all child renderers of the bowl
        foreach (Renderer childRenderer in childRenderers)
        {
            childRenderer.material = highlightMaterial;
        }

        // Update the highlighted bowl
        highlightedBowl = bowl;
    }

    void ResetHighlight()
    {
        // Check if there was a previously highlighted bowl
        if (highlightedBowl != null && originalMaterialsDict.ContainsKey(highlightedBowl))
        {
            Dictionary<Renderer, Material> originalMaterials = originalMaterialsDict[highlightedBowl];

            // Reset the material of all child renderers of the previously highlighted bowl
            foreach (var originalMaterialPair in originalMaterials)
            {
                Renderer childRenderer = originalMaterialPair.Key;
                Material originalMaterial = originalMaterialPair.Value;

                childRenderer.material = originalMaterial;
            }

            // Clear the original materials dictionary for the highlighted bowl
            originalMaterialsDict.Remove(highlightedBowl);
            highlightedBowl = null;
        }
    }
}
