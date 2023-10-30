using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public PlayerShoot PlayerShoot;

  
    public int puntos;
   
    void Awake() 
    {
        instance = this;
    }


    public void CollectAmmo()
    {
        // Incrementar balas actuales del jugador
        PlayerShoot.currentBullets += 1;

        // Limitar al máximo de balas
        PlayerShoot.currentBullets = Mathf.Min(PlayerShoot.currentBullets, PlayerShoot.maxbullets);

        Debug.Log("Balas actuales: " + PlayerShoot.currentBullets);
    }

}
