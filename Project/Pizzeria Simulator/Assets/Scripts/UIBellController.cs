using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class UIBellController : MonoBehaviour
{
    public TextMeshProUGUI RecipeText;
    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI ScoreText;

    private float elapsedTime = 0f;
    private float totalTime = 5f;

    private string currentRecipe = string.Empty;
    private string recipesFolderPath = "Assets/Recipes";

    // Update is called once per frame
    void Update()
    {
        UpdateTime();

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

    private void PrintNextRecipe()
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
            currentRecipe = recipeText;
        }
        else
        {
            Debug.LogWarning("No recipe files found in the Recipes folder.");
        }
    }

    public string GetCurrentRecipeText()
    {
        return currentRecipe;
    }

    public void UpdateScore(int score)
    {
        int playerScore = int.Parse(ScoreText.text.Split(" ")[1]);
        ScoreText.text = "Score: " + (score + playerScore);
    }

    private void UpdateTime()
    {
        elapsedTime += Time.deltaTime;

        float remainingTime = totalTime - elapsedTime;

        // Calculate absolute value of remaining time
        float absRemainingTime = Mathf.Abs(remainingTime);

        // Update UI text with formatted time (e.g., minutes:seconds)
        int minutes = Mathf.FloorToInt(absRemainingTime / 60f);
        int seconds = Mathf.FloorToInt(absRemainingTime % 60f);
        
        // Adjust sign based on remaining time
        string sign = (remainingTime < 0) ? "-" : "";

        TimerText.text = string.Format("{0}{1:00}:{2:00}", sign, minutes, seconds);
    }
}
