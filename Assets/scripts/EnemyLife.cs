using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public int life = 5;

    // Reducir la vida del enemigo y verificar si está vivo.
    public void TakeDamage(int value)
    {
        life -= value;

        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }

   private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            // Obtener una referencia al script de la bala.
            Bullet bullet = other.GetComponent<Bullet>();

            if (bullet != null)
            {
                // Llamar a la función TakeDamage de la bala para reducir la vida del enemigo.
                TakeDamage(bullet.damage);
            }

            // Destruir la bala después de impactar con el enemigo.
            Destroy(other.gameObject);
        }
    }
}
