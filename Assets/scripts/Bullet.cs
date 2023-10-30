using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //[SerializeField] private float speed = 10f;
    public int damage = 10; // Cambiamos la variable damage para que sea pública.


    void Start()
    {
        // Destruye la bala después de 1 segundos.
        Destroy(gameObject, 1f);
    }
}
