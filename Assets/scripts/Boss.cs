using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Boss : MonoBehaviour
{
    // Variable para el Rigidbody2D del boss
    private Rigidbody2D rb;

    // Variable para la velocidad del boss
    [SerializeField] private float speed = 5f;

    // Variable para la dirección del boss
    private Vector2 direction = Vector2.left;

    // Variable para el límite izquierdo del movimiento
    [SerializeField] private float leftLimit = -2f;

    // Variable para el límite derecho del movimiento
    [SerializeField] private float rightLimit = 2f;

    // Método que se ejecuta al iniciar el juego
    void Start()
    {
        // Obtener el componente Rigidbody2D del boss
        rb = GetComponent<Rigidbody2D>();
    }

    // Método que se ejecuta en cada frame del juego
    void Update()
    {
        // Calcular la posición x del boss usando la función PingPong
        float x = Mathf.PingPong(Time.time * speed, rightLimit - leftLimit) + leftLimit;

        // Crear un vector con la posición x y la posición y actual del boss
        Vector2 position = new Vector2(x, rb.position.y);

        // Mover el boss a la nueva posición usando la función MovePosition
        rb.MovePosition(position);
    }
}

