using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    public int damage = 10; 
    void Start()
    {
        // Destruye la bala después de 1 segundos.
        Destroy(gameObject, 1f);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //si colisiona con un objeto que tenga el tag "Boss" se destruye
        if (collision.gameObject.tag == "Boss")
        {
            Destroy(gameObject);
        }
    }
}