using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class FruitGenerator : MonoBehaviour
{
    // Prefabs de las frutas
    [SerializeField] private GameObject applePrefab;
    [SerializeField] private GameObject bananaPrefab;

    // Nombre de la escena donde generar frutas
    [SerializeField] private string targetSceneName = "Scene2"; // Configura en el Inspector

    // Lista de puntos de spawn
    [SerializeField] private Transform[] spawnPoints; // Asigna GameObjects vacíos en el Inspector

    // Número de frutas a generar
    [SerializeField] private int maxApples = 5;
    [SerializeField] private int maxBananas = 7;

    void Start()
    {
        // Debug: Imprimir escena actual
        Scene currentScene = SceneManager.GetActiveScene();
        Debug.Log($"Escena actual: {currentScene.name} (BuildIndex: {currentScene.buildIndex})");

        // Verificar prefabs
        if (applePrefab == null || bananaPrefab == null)
        {
            Debug.LogError("applePrefab o bananaPrefab NO están asignados en el Inspector. Arrástralos desde Assets.");
            return;
        }
        Debug.Log("Prefabs asignados correctamente.");

        // Verificar componentes en prefabs
        if (!applePrefab.GetComponent<EfectoSonido>() || !bananaPrefab.GetComponent<EfectoSonido>())
        {
            Debug.LogWarning("Uno de los prefabs (applePrefab o bananaPrefab) no tiene el componente EfectoSonido.");
        }
        if (!applePrefab.GetComponent<CollectibleItem>() || !bananaPrefab.GetComponent<CollectibleItem>())
        {
            Debug.LogWarning("Uno de los prefabs (applePrefab o bananaPrefab) no tiene el componente CollectibleItem.");
        }

        // Verificar puntos de spawn
        if (spawnPoints == null || spawnPoints.Length < (maxApples + maxBananas))
        {
            Debug.LogError($"La lista de spawnPoints tiene {spawnPoints?.Length ?? 0} puntos, pero se necesitan al menos {maxApples + maxBananas} para {maxApples} manzanas y {maxBananas} bananas.");
            return;
        }

        // Verificar si estamos en la escena correcta
        if (currentScene.name == targetSceneName)
        {
            Debug.Log($"Generando frutas en {targetSceneName}...");
            GenerateFruits();
        }
        else
        {
            Debug.LogWarning($"No es la escena correcta (nombre: {currentScene.name}). Configura 'Target Scene Name' a '{currentScene.name}'.");
        }
    }

    void GenerateFruits()
    {
        // Crear una lista de índices de spawnPoints disponibles
        List<int> availableIndices = new List<int>();
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (spawnPoints[i] != null)
                availableIndices.Add(i);
            else
                Debug.LogWarning($"spawnPoints[{i}] es null. Asegúrate de asignar todos los puntos en el Inspector.");
        }

        if (availableIndices.Count < (maxApples + maxBananas))
        {
            Debug.LogError($"No hay suficientes puntos de spawn válidos ({availableIndices.Count}) para {maxApples} manzanas y {maxBananas} bananas.");
            return;
        }

        // Generar manzanas
        Debug.Log($"Generando {maxApples} manzanas.");
        for (int i = 0; i < maxApples; i++)
        {
            if (availableIndices.Count == 0)
            {
                Debug.LogWarning("No hay más puntos de spawn disponibles para manzanas.");
                break;
            }

            int randomIndex = availableIndices[Random.Range(0, availableIndices.Count)];
            Vector2 spawnPosition = spawnPoints[randomIndex].position;
            GameObject fruit = Instantiate(applePrefab, spawnPosition, Quaternion.identity);
            Debug.Log($"Manzana generada en: {spawnPosition}");

            CollectibleItem collectible = fruit.GetComponent<CollectibleItem>();
            if (collectible != null)
                collectible.type = CollectibleItem.ItemType.Apple;

            availableIndices.Remove(randomIndex); // Evitar reutilizar la posición
        }

        // Generar bananas
        Debug.Log($"Generando {maxBananas} bananas.");
        for (int i = 0; i < maxBananas; i++)
        {
            if (availableIndices.Count == 0)
            {
                Debug.LogWarning("No hay más puntos de spawn disponibles para bananas.");
                break;
            }

            int randomIndex = availableIndices[Random.Range(0, availableIndices.Count)];
            Vector2 spawnPosition = spawnPoints[randomIndex].position;
            GameObject fruit = Instantiate(bananaPrefab, spawnPosition, Quaternion.identity);
            Debug.Log($"Banana generada en: {spawnPosition}");

            CollectibleItem collectible = fruit.GetComponent<CollectibleItem>();
            if (collectible != null)
                collectible.type = CollectibleItem.ItemType.Banana;

            availableIndices.Remove(randomIndex); // Evitar reutilizar la posición
        }
    }

    void OnDrawGizmos()
    {
        if (spawnPoints == null) return;

        Gizmos.color = Color.green;
        foreach (Transform point in spawnPoints)
        {
            if (point != null)
                Gizmos.DrawWireSphere(point.position, 0.5f);
        }
    }
}