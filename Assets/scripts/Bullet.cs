using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10; 
    void Start()
    {
        // Destruye la bala después de 1 segundos.
        Destroy(gameObject, 1f);
    }
}
