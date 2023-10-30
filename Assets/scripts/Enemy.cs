using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour 
{
    public float speed = 5f;
    public float maxOffset = 5f;
    private float direction = 1f;
    
    void Update()
    {
        transform.Translate(Vector2.right * speed * direction * Time.deltaTime);

        if(transform.position.x >= maxOffset) {
            direction = -1f; 
        }
        
        if(transform.position.x <= -maxOffset) {
            direction = 1f;
        }
    }
}