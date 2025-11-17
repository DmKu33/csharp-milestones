using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// game manager for chapter 8
/// </summary>
public class GameManager : MonoBehaviour
{
    // chapter 8 - properties: get and set
    private int health = 100;
    private int itemCount = 0;
    private bool hasWon = false;

    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    public int ItemCount
    {
        get { return itemCount; }
        set { itemCount = value; }
    }

    public bool HasWon
    {
        get { return hasWon; }
        set { hasWon = value; }
    }

    // chapter 8 - ui: text elements
    public Text healthText;
    public Text itemText;
    public Text winText;

    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        // example: check win condition
        if (itemCount >= 5 && !hasWon)
        {
            hasWon = true;
            UpdateUI();
        }

        // chapter 8 - pause: time.timescale
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                Debug.Log("Game Paused");
            }
            else
            {
                Time.timeScale = 1;
                Debug.Log("Game Resumed");
            }
        }
    }

    // chapter 8 - ui: update text
    void UpdateUI()
    {
        if (healthText != null)
        {
            healthText.text = $"Health: {health}";
        }

        if (itemText != null)
        {
            itemText.text = $"Items: {itemCount}";
        }

        if (winText != null)
        {
            winText.text = hasWon ? "You Win!" : "";
        }
    }
}

