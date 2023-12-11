using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class UIBellController : MonoBehaviour
{
    public TextMeshProUGUI RecipeText;
    private string recipesFolderPath = "Assets/Recipes";

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

            // Check if the object is the bell
            if (hitObject.CompareTag("Bell") && Input.GetKeyDown(KeyCode.E))
            {
                //print the next recipe
                PrintNextRecipe();
            }
        }
    }

    void PrintNextRecipe()
    {
        // Get all recipe files in the Recipes folder
        string[] recipeFiles = Directory.GetFiles(recipesFolderPath, "*.txt");

        // Check if there are any recipe files
        if (recipeFiles.Length > 0)
        {
            // Choose a random recipe file
            string randomRecipeFile = recipeFiles[Random.Range(0, recipeFiles.Length)];

            // Read the text from the chosen file
            string recipeText = File.ReadAllText(randomRecipeFile);

            // Set the TextMeshPro text
            RecipeText.text = recipeText;
        }
        else
        {
            Debug.LogWarning("No recipe files found in the Recipes folder.");
        }
    }
}
