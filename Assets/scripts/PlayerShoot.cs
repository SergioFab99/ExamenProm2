using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; // Arrastra aquí el prefab de la bala.
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float cooldownTime = 0.01f;

    private float lastShotTime;
    private Vector3 lastShootDirection; // Almacena la última dirección de disparo.

    void Start()
    {
        lastShotTime = -cooldownTime; // Inicializamos para permitir el primer disparo.
    }

    void Update()
    {
        // Detectamos la dirección de movimiento del jugador.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0).normalized;

        if (moveDirection != Vector3.zero)
        {
            // Si el jugador se está moviendo, actualizamos la dirección de disparo.
            lastShootDirection = moveDirection;
        }

        if (Input.GetKeyDown(KeyCode.Space) && Time.time - lastShotTime >= cooldownTime)
        {
            Shoot();
            lastShotTime = Time.time;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        // Disparamos en la última dirección de disparo.
        rb.velocity = lastShootDirection * bulletSpeed;
    }
}