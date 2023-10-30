using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
  
    public int puntos;
   
    void Awake() {
        instance = this;
    }

    public void CollectAmmo() 
    {
        puntos += 1; 
        Debug.Log("Puntos actuales: " + puntos);
        // Si puntos es igual a 10, cambia a la escena de victoria
        if (puntos == 10)
        {
            SceneManager.LoadScene("Victoria");
        }
    }
    
}
