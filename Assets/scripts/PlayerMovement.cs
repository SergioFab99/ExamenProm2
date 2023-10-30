using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour {

    public float speed = 5f;
    
    public int health = 100;

    void Update() 
    {
        // Movimiento del jugador
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, vertical, 0);
        transform.position += movement * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other) {
        // Recoger moneda
        if (other.CompareTag("Moneda")) 
        {
            Destroy(other.gameObject);
            // Código para sumar puntos
        }
    }

}