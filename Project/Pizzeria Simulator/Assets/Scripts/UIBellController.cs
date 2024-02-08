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

    private string difficulty;

    private float elapsedTime = 0f;
    private float totalTime;
    private float absRemainingTime;
    private string sign;
    private bool colorChanged = false;

    private string currentRecipe = string.Empty;
    private string recipesFolderPath = "Assets/Recipes";

    void Start()
    {
        difficulty = PlayerPrefs.GetString("difficulty");
        if(difficulty != null)
        {
            Debug.Log("Difficulty level: " + difficulty);
        }
        else
        {
            Debug.Log("No difficulty detected");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(currentRecipe != string.Empty)
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
                AudioSource audioSource = hitObject.GetComponents<AudioSource>()[0];
                audioSource.Play();

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

            //Set the times
            if(difficulty == "easy")
                totalTime = Mathf.FloorToInt(Random.Range(45, 61));
            else if(difficulty == "medium")
                totalTime = Mathf.FloorToInt(Random.Range(30, 51));
            else
                totalTime = 5f;
            elapsedTime = 0f;
            TimerText.color = Color.yellow;
            colorChanged = false;
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
        if(sign == "")
        {
            ScoreText.text = "Score: " + (score + playerScore + Mathf.FloorToInt(absRemainingTime));
        }
        else
        {
            ScoreText.text = "Score: " + (score + playerScore - Mathf.FloorToInt(absRemainingTime));
        }

        RecipeText.text = string.Empty;
    }

    private void UpdateTime()
    {
        elapsedTime += Time.deltaTime;

        float remainingTime = totalTime - elapsedTime;

        // Calculate absolute value of remaining time
        absRemainingTime = Mathf.Abs(remainingTime);

        // Update UI text with formatted time (e.g., minutes:seconds)
        int minutes = Mathf.FloorToInt(absRemainingTime / 60f);
        int seconds = Mathf.FloorToInt(absRemainingTime % 60f);
        
        // Adjust sign based on remaining time
        sign = (remainingTime < 0) ? "-" : "";

        // Change color to red if remaining time is below 0
        if (remainingTime <= 0 && !colorChanged)
        {
            TimerText.color = Color.red;
            colorChanged = true;
        }

        TimerText.text = string.Format("{0}{1:00}:{2:00}", sign, minutes, seconds);
    }
}
