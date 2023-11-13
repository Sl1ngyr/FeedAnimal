using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public static bool isDestroyOutOfBounds = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall") && gameObject.CompareTag("Animal"))
        {
            Debug.Log("MUUUUU");
            isDestroyOutOfBounds = true;
            Destroy(gameObject);
        }
        else if(other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
