using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30;
    private float lowBound = -10;
    private float sideBound = 25;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound || transform.position.z < lowBound || transform.position.x < -sideBound || transform.position.x > sideBound)
        {
            Destroy(gameObject);
        }
    }
}
