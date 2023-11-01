using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Boss : MonoBehaviour 
{
    public int maxVida = 100;
    public int vidaActual;

    public float velocidad;
    public int dañoContacto;
    public Transform limiteIzq, limiteDer;

    public GameObject bala;
    public float fireRate;
    private float ultimoDisparo;

    void Start()
    {
        vidaActual = maxVida; 
    }

    void Update()
    {
        if (vidaActual > maxVida * 0.5f) 
        {
            // Movimiento izquierda-derecha (Enemigo1)
            transform.Translate(Vector2.right * velocidad * Time.deltaTime);

            if (transform.position.x > limiteDer.position.x) 
            {
                velocidad = -Mathf.Abs(velocidad);
            }
            else if (transform.position.x < limiteIzq.position.x) 
            {
                velocidad = Mathf.Abs(velocidad);
            }
        }
        else 
        {
             // Disparo hacia el jugador (Enemigo2)
             if(Time.time > ultimoDisparo + fireRate)
             {
                 Instantiate(bala, transform.position, transform.rotation);
                 ultimoDisparo = Time.time;  
             }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player") 
        {
            
            // En lugar de VidaJugador:
            col.gameObject.GetComponent<PlayerLife>().RecibirDaño(dañoContacto); 
        }
    }

}
