using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// learning curve script for c#
/// </summary>
public class LearningCurve : MonoBehaviour
{
    // chapter 2: variables
    public int currentAge = 30;
    public float currentHeight = 5.8f;
    public string characterName = "Hero";
    public bool isActive = true;
    
    private int experiencePoints = 0;
    private bool hasKey = false;

    /*
     * multi-line comment
     */

    // single line comment
    void Start()
    {
        // chapter 2 - variables: basics
        Debug.Log(currentAge);
        Debug.Log(currentHeight);
        Debug.Log(characterName);
        Debug.Log(isActive);

        // chapter 3 - methods: debug.logformat
        Debug.LogFormat("Name: {0}, Age: {1}", characterName, currentAge);
        
        // string concatenation with +
        string message = "Name: " + characterName + ", Age: " + currentAge;
        Debug.Log(message);
        
        // string interpolation with $
        Debug.Log($"Height: {currentHeight}, Active: {isActive}");
        
        // methods
        int sum = AddNumbers(5, 10);
        Debug.Log(sum);
        
        string greeting = GenerateGreeting(characterName, currentAge);
        Debug.Log(greeting);

        // chapter 4 - conditionals: if, else if, else
        if (currentAge < 18)
        {
            Debug.Log("Minor");
        }
        else if (currentAge < 65)
        {
            Debug.Log("Adult");
        }
        else
        {
            Debug.Log("Senior");
        }
        
        // test for true and !true
        if (isActive)
        {
            Debug.Log("Active");
        }
        
        if (!hasKey)
        {
            Debug.Log("No key");
        }
        
        // nested if
        if (experiencePoints > 100)
        {
            if (currentAge > 25)
            {
                Debug.Log("Experienced adult");
            }
        }
        
        // switch statement
        int day = 3;
        switch (day)
        {
            case 1:
                Debug.Log("Monday");
                break;
            case 3:
                Debug.Log("Wednesday");
                break;
            default:
                Debug.Log("Other day");
                break;
        }

        // collections: array
        int[] scores = { 100, 95, 87 };
        
        // collections: list
        List<string> items = new List<string> { "Potion", "Scroll", "Key" };
        
        // collections: dictionary
        Dictionary<string, int> inventory = new Dictionary<string, int>
        {
            { "Gold", 50 },
            { "Potions", 3 }
        };

        // for loop to print specific index
        for (int i = 0; i < items.Count; i++)
        {
            if (i == 1)
            {
                Debug.Log(items[i]);
            }
        }
        
        // foreach loop for list
        foreach (string item in items)
        {
            Debug.Log(item);
        }
        
        // foreach loop for dictionary
        foreach (KeyValuePair<string, int> kvp in inventory)
        {
            Debug.Log($"{kvp.Key}: {kvp.Value}");
        }
    }

    // method with parameters
    int AddNumbers(int a, int b)
    {
        return a + b;
    }

    // method with return type
    string GenerateGreeting(string name, int age)
    {
        return $"Hello, {name}, age {age}";
    }

    void Update()
    {
    }
}