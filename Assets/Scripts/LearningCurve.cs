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

    // chapter 8: character control
    public float jumpForce = 5.0f;
    public LayerMask groundLayer;
    private bool isGrounded = true;

    // chapter 8: shooting mechanic
    public GameObject projectilePrefab;
    public float projectileSpeed = 10.0f;

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

        // chapter 5 - classes: instantiate character objects
        Character hero = new Character("Arin", 100);
        hero.PrintStatsInfo();

        Character heroine = new Character("Lyra", 150);
        heroine.PrintStatsInfo();

        // chapter 5 - structs: instantiate weapon objects
        Weapon huntingBow = new Weapon("Hunting Bow", 25);
        huntingBow.PrintWeaponInfo();

        Weapon warBow = new Weapon("War Bow", 45);
        warBow.PrintWeaponInfo();

        // chapter 5 - child classes: instantiate paladin
        Weapon knightSword = new Weapon("Knight's Sword", 55);
        Paladin knight = new Paladin("Sir Galahad", 200, knightSword);
        knight.PrintStatsInfo();

        // chapter 5 - referencing objects: get component
        Transform cameraTransform = GetComponent<Transform>();
        Debug.Log($"Camera position: {cameraTransform.localPosition}");

        GameObject lightObject = GameObject.Find("Directional Light");
        if (lightObject != null)
        {
            Transform lightTransform = lightObject.GetComponent<Transform>();
            Debug.Log($"Light position: {lightTransform.localPosition}");
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

    // chapter 7 - movement: keyboard input
    void Update()
    {
        float moveSpeed = 5.0f;
        float rotateSpeed = 75.0f;

        // vertical movement
        float vInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * vInput * moveSpeed * Time.deltaTime);

        // horizontal rotation
        float hInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * hInput * rotateSpeed * Time.deltaTime);

        // chapter 8 - jump: keycode enum
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
        }

        // chapter 8 - shooting: instantiate projectile
        if (Input.GetMouseButtonDown(0) && projectilePrefab != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
            Destroy(projectile, 3f);
        }
    }

    // chapter 7 - physics: fixed update
    void FixedUpdate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.MovePosition(transform.position + transform.forward * Time.fixedDeltaTime); // example 
        }
    }

    // chapter 7 - collision detection
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collided with: {collision.gameObject.name}");
        Destroy(collision.gameObject); // example

        // chapter 8 - isgrounded: layer mask check
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            isGrounded = true;
        }
    }

    // chapter 7 - trigger enter
    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger entered: {other.gameObject.name}");
    }

    // chapter 7 - trigger exit
    void OnTriggerExit(Collider other)
    {
        Debug.Log($"Trigger exited: {other.gameObject.name}");
    }
}
