using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    // El prefab de la moneda que queremos instanciar.
    [SerializeField] private GameObject coinPrefab;
    // El tiempo de espera entre cada generación de monedas.
    [SerializeField] private float spawnDelay = 2.0f;
    // Radio en el que se generan las monedas.
    [SerializeField] private float spawnRadius = 5.0f; 

    private float timeSinceLastSpawn = 0.0f;

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnDelay)
        {
            // Llama a la función para generar una moneda.
            SpawnCoin();
            // Reinicia el temporizador.
            timeSinceLastSpawn = 0.0f; 
        }
    }

    void SpawnCoin()
    {
        // Genera una posición aleatoria dentro del radio especificado.
        Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;

        // Suma la posición aleatoria a la posición del spawner.
        Vector3 spawnPosition = transform.position + new Vector3(randomPosition.x, randomPosition.y, 0);

        // Genera una nueva moneda en la posición aleatoria.
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
    }
}
