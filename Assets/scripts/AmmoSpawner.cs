using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{
    // El prefab de la moneda que queremos instanciar.
    [SerializeField] private GameObject coinPrefab;
    // El tiempo de espera entre cada generación de monedas.
    [SerializeField] private float spawnDelay = 2.0f;
    // Radio en el que se generan las monedas.
    [SerializeField] private float spawnRadius = 5.0f; 
    // Temporizador para controlar el tiempo entre generaciones.
    private float timeSinceLastSpawn = 0.0f;

    void Update()
    {
        // Incrementa el temporizador.
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnDelay)
        {
            // Llama a la función para generar una moneda.
            SpawnAmmo();
            // Reinicia el temporizador.
            timeSinceLastSpawn = 0.0f; 
        }
    }

    void SpawnAmmo()
    {
        // Genera una posición aleatoria dentro del radio especificado.
        Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;

        // Suma la posición aleatoria a la posición del spawner.
        Vector3 spawnPosition = transform.position + new Vector3(randomPosition.x, randomPosition.y, 0);

        // Genera una nueva moneda en la posición aleatoria.
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
    }
}
