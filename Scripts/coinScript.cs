using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour
{

    private float Score = 0f;
    
    void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.CompareTag("Player")) 
        {
            Score = 10f;
            Destroy(gameObject);
        }
        Debug.Log(Score);
    }
}
