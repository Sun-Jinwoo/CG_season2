using UnityEngine;
using UnityEngine.SceneManagement;

public class FruitGenerator : MonoBehaviour
{
    // Prefabs de las frutas
    [SerializeField] private GameObject applePrefab;
    [SerializeField] private GameObject bananaPrefab;

    // Límites de generación (ajusta según tu escena)
    [SerializeField] private float minX = -10f;
    [SerializeField] private float maxX = 10f;
    [SerializeField] private float spawnY = 10f; // Altura inicial desde donde se lanza el raycast

    // Capa del suelo
    [SerializeField] private LayerMask groundLayer;

    // Número máximo de frutas
    [SerializeField] private int maxApples = 5;
    [SerializeField] private int maxBananas = 7;

    void Start()
    {
        // Verificar si estamos en la Escena 2
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            GenerateFruits();
        }
    }

    void GenerateFruits()
    {
        // Generar un número aleatorio de manzanas (1 a maxApples)
        int appleCount = Random.Range(1, maxApples + 1);
        for (int i = 0; i < appleCount; i++)
        {
            SpawnFruit(applePrefab);
        }

        // Generar un número aleatorio de bananas (1 a maxBananas)
        int bananaCount = Random.Range(1, maxBananas + 1);
        for (int i = 0; i < bananaCount; i++)
        {
            SpawnFruit(bananaPrefab);
        }
    }

    void SpawnFruit(GameObject fruitPrefab)
    {
        // Generar una posición X aleatoria dentro de los límites
        float randomX = Random.Range(minX, maxX);
        Vector2 raycastOrigin = new Vector2(randomX, spawnY);

        // Lanzar un raycast hacia abajo para encontrar el suelo
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, Vector2.down, Mathf.Infinity, groundLayer);

        if (hit.collider != null)
        {
            // Colocar la fruta justo encima del suelo
            Vector2 spawnPosition = hit.point + Vector2.up * 0.1f; // Pequeño offset para evitar colisión con el suelo
            Instantiate(fruitPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            // Si no se encuentra el suelo, intentar de nuevo (evitar bucles infinitos)
            Debug.LogWarning("No se encontró el suelo para generar una fruta en X: " + randomX);
            SpawnFruit(fruitPrefab); // Reintentar
        }
    }

    // Visualizar los límites en el editor
    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector2(minX, spawnY), new Vector2(maxX, spawnY));
        Gizmos.DrawLine(new Vector2(minX, spawnY), new Vector2(minX, spawnY - 10f));
        Gizmos.DrawLine(new Vector2(maxX, spawnY), new Vector2(maxX, spawnY - 10f));
    }
}