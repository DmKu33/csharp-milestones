using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// projectile script for chapter 8
/// </summary>
public class Projectile : MonoBehaviour
{
    public float speed = 10.0f;

    void Start()
    {
        // chapter 8 - shooting: rigidbody velocity
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = transform.forward * speed;
        }
    }
}

