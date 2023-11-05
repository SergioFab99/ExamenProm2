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
    //si no quedan enemigos en la escena ,cambiar al nivel 2
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            SceneManager.LoadScene("Nivel2");
        }
    }
}
