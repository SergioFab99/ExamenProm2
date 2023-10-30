using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy2 : MonoBehaviour
{   
    [SerializeField] private float speed = 2f;

    private bool movingUp = true;

    private float topBoundary = 1f;
    private float bottomBoundary = -1f;

    void Update()
    {
        if(movingUp)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        else 
        {
            transform.position += Vector3.down * speed * Time.deltaTime;        
        }

        if(transform.position.y >= topBoundary)
        {
            movingUp = false;
        }
        else if(transform.position.y <= bottomBoundary)
        {
            movingUp = true;
        }
    }

}