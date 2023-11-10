using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public static bool isDestroyOutOfBounds = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            isDestroyOutOfBounds = true;
            Destroy(gameObject);
        }
        else if (other.tag == "Wall" && gameObject.tag == "Food")
        {
            Destroy(gameObject);
        }
    }
}
