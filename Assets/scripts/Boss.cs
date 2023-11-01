using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Boss : MonoBehaviour
{
    // Variable para el Rigidbody2D del boss
    private Rigidbody2D rb;

    // Variable para la velocidad del boss
    public float speed = 5f;

    // Variable para la dirección del boss
    private Vector2 direction = Vector2.left;

    // Variable para el límite izquierdo del movimiento
    public float leftLimit = -4f;

    // Variable para el límite derecho del movimiento
    public float rightLimit = 4f;

    // Variable para la vida del boss
    public float health = 100f;

    // Variable para el valor de vida que indica que el boss está herido
    public float hurtValue = 50f;

    // Variable para el estado del boss
    private string state = "normal";

    // Variable para el prefab de la bala
    public GameObject bulletPrefab;

    // Variable para la posición de salida de la bala
    public Transform bulletSpawn;

    // Variable para la velocidad de la bala
    public float bulletSpeed = 10f;

    // Variable para el intervalo de tiempo entre disparos
    public float shootInterval = 1f;

    // Variable para el contador de tiempo
    private float timer = 0f;

    // Método que se ejecuta al iniciar el juego
    void Start()
    {
        // Obtener el componente Rigidbody2D del boss
        rb = GetComponent<Rigidbody2D>();
    }

    // Método que se ejecuta en cada frame del juego
    void Update()
    {
        // Comparar la vida del boss con el valor de vida que indica que está herido
        if (health <= hurtValue)
        {
            // Cambiar el estado del boss a "hurt"
            state = "hurt";
        }

        // Ejecutar el código según el estado del boss
        switch (state)
        {
            case "normal":
                // Calcular la posición x del boss usando la función PingPong
                float x = Mathf.PingPong(Time.time * speed, rightLimit - leftLimit) + leftLimit;

                // Crear un vector con la posición x y la posición y actual del boss
                Vector2 position = new Vector2(x, rb.position.y);

                // Mover el boss a la nueva posición usando la función MovePosition
                rb.MovePosition(position);
                break;
            case "hurt":
                // Hacer que el boss se quede quieto
                rb.velocity = Vector2.zero;

                // Incrementar el contador de tiempo con el tiempo transcurrido desde el último frame
                timer += Time.deltaTime;

                // Comparar el contador de tiempo con el intervalo de tiempo entre disparos
                if (timer >= shootInterval)
                {
                    // Disparar una bala hacia la izquierda usando la función Instantiate
                    GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
                    bullet.GetComponent<Rigidbody2D>().velocity = Vector2.left * bulletSpeed;

                    // Reiniciar el contador de tiempo a cero
                    timer = 0f;
                }
                break;
        }
    }
}