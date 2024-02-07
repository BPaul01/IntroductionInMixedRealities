using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreController : MonoBehaviour
{
    //private bool isPizzaOnTray = false;
    private UIBellController uiBellController;

    private List<string> toppings = new List<string>();
    private string material;

    private int score;
    private bool updatedScore = false;

    private GameObject pizzaObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pizza"))
        {
            Debug.Log("Pizza was detected on the evaluation tray");

            //Obtain Pizza Object
           pizzaObject = other.gameObject;

            //Get pizza toppings
            for (int i = 0; i < pizzaObject.transform.childCount; i++)
            {
                Transform child = pizzaObject.transform.GetChild(i);

                //Keep the toppings names
                //Debug.Log(child.name);
                if(child.name.Contains("Top") && child.transform.childCount > 0)
                {
                    Transform topping = child.transform.GetChild(0);
                    toppings.Add(topping.name);
                    //Debug.Log(topping.name);
                }
                //Keep the stage of cooking
                else if(child.name.Contains("Torus")){
                    Renderer renderer = child.GetComponent<Renderer>();
                    if (renderer != null)
                    {
                        material = renderer.material.name.Trim();
                        //Debug.Log("Material is:" + material);
                    }
                }
            }

            //Start checking the pizza
            string currentRecipe = uiBellController.GetCurrentRecipeText();
            //Debug.Log(currentRecipe);

            score =  MakeScore(currentRecipe, toppings);
            Debug.Log("Scorul obtinut: " + score + " points");

            //Update the score
            if(!updatedScore)
            {
                uiBellController.UpdateScore(score);
                updatedScore = true;
                Destroy(pizzaObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pizza"))
        {
            Debug.Log("Pizza is no longer detected on the evaluation tray");
            //isPizzaOnTray = false;
            updatedScore = false;
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

    private int MakeScore(string currentRecipe, List<string> toppings)
    {
        string[] ingredients = currentRecipe.Split('\n');
        ingredients = ingredients.Skip(1).ToArray();
        string ingredientToCompare;

        int score = 10 * ingredients.Length;
        bool find;
        //Debug.Log("Score Initial: "+ score);
        //Verify every ingredient from the recipe
        foreach (string ingredient in ingredients)
        {   
            ingredientToCompare = ingredient.Substring(2).ToLower().Replace(" ", "_");
            ingredientToCompare = ingredientToCompare.Trim();

            //Debug.Log("Ingredient: " + ingredientToCompare + ingredientToCompare.Length);

            find = false;

            //Debug.Log(ingredientToCompare);

            //Find a correspondent in toppings
            foreach (string topping in toppings)
            {
                
                //Debug.Log("Topping: " + topping);
                if (topping.ToLower().Contains(ingredientToCompare))
                {
                    //Debug.Log("Ingredient: "+ ingredientToCompare + " - " + "Topping: " +topping);
                    find = true;
                    break;
                }
            }

            //Not found the ingredient in the toppings -> -10 points
            if (!find)
            {
                score -= 10;
            }
        }

        //Debug.Log("Material: " + material);

        //Verify the stage of cooking
        if(material.Contains("Raw") || material.Contains("SemiCooked")){
            score -= 20;
        }
        else if(material.Contains("Burnt")){
            score = -20;
        }
        else if(material.Contains("Cooked")){
            score += 20;
        }
        
        return score;
    } 

}
