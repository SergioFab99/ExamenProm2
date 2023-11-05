using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int maxBullets = 20;
    public int currentBullets;

    void Awake()
    {
        instance = this;
        currentBullets = maxBullets;
        //con esta lógica evitamos que aparezca "is loading" y unity crashe ,es un solucionador de errores
        if (instance == null)
        {
            instance = this;
            // Evita que se destruya al cambiar de escena.
            DontDestroyOnLoad(this.gameObject); 
            currentBullets = maxBullets;
        }
        else
        {
            // Si ya existe una instancia, destruye esta.
            Destroy(this.gameObject); 
        }
    }

    public void CollectAmmo()
    {
        if(currentBullets == maxBullets) 
        {
            // Balas llenas, aumentar máximo
            maxBullets += 5;
        }
        else 
        {
            // Balas no llenas, recargar hasta máximo actual
            currentBullets = Mathf.Min(currentBullets + 5, maxBullets); 
        }
    }
    // Si está en la escena "Nivel1" y no hay objetos con el tag "Enemy" cambiar a la escena "Nivel2"
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Nivel1" && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            SceneManager.LoadScene("Nivel2");
        }
        // Si está en la escena "Nivel2" y no hay objetos con el tag "Enemy" cambiar a la escena "Nivel3"
        if (SceneManager.GetActiveScene().name == "Nivel2" && GameObject.FindGameObjectsWithTag("Boss").Length == 0)
        {
            SceneManager.LoadScene("Victoria");
        }
    }
}