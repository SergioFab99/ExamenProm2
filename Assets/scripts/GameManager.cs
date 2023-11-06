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
        var sceneName = SceneManager.GetActiveScene().name; 
        Debug.Log("Current scene: " + sceneName);

        if (sceneName == "Nivel1" && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            Debug.Log("Switching to Nivel2");
            SceneManager.LoadScene("Nivel2");
        }
        if (sceneName == "Nivel2" && GameObject.FindGameObjectsWithTag("Boss").Length == 0)
        {
            Debug.Log("Switching to Victoria");
            SceneManager.LoadScene("Victoria");
        }
    }
}