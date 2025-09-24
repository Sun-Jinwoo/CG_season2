using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel; // Referencia al panel UI
    [SerializeField] private TextMeshProUGUI textApples; // Texto para manzanas
    [SerializeField] private TextMeshProUGUI textBananas; // Texto para bananas
    [SerializeField] private TextMeshProUGUI textTime; // Texto para tiempo
    [SerializeField] private Button saveButton; // Botón para guardar datos

    // Clase serializable para los datos del juego
    [System.Serializable]
    private class GameData
    {
        public int scoreApples;
        public int scoreBananas;
        public float globalTime;
    }

    void Start()
    {
        // Asegurarse de que el panel esté desactivado al inicio
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("gameOverPanel no está asignado en GameOverPanel.");
        }

        // Verificar asignaciones
        if (textApples == null) Debug.LogError("textApples no está asignado en GameOverPanel.");
        if (textBananas == null) Debug.LogError("textBananas no está asignado en GameOverPanel.");
        if (textTime == null) Debug.LogError("textTime no está asignado en GameOverPanel.");
        if (saveButton == null) Debug.LogError("saveButton no está asignado en GameOverPanel.");

        // Añadir listener al botón
        if (saveButton != null)
        {
            saveButton.onClick.AddListener(SaveGameData);
        }
    }

    // Activar el panel y mostrar los totales
    public void ShowGameOverPanel()
    {
        if (gameOverPanel == null || GameManager.Instance == null) return;

        // Pausar el juego
        Time.timeScale = 0f;

        // Actualizar los textos con los totales
        if (textApples != null)
            textApples.text = $"Manzanas: {GameManager.Instance.ScoreApples}";
        if (textBananas != null)
            textBananas.text = $"Bananas: {GameManager.Instance.ScoreBananas}";
        if (textTime != null)
            textTime.text = $"Tiempo: {GameManager.Instance.GlobalTime:F2} s";

        // Activar el panel
        gameOverPanel.SetActive(true);
        Debug.Log("Panel de fin de juego mostrado.");
    }

    // Guardar los datos en un archivo JSON
    private void SaveGameData()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager.Instance es null. No se pueden guardar los datos.");
            return;
        }

        // Crear objeto con los datos
        GameData data = new GameData
        {
            scoreApples = GameManager.Instance.ScoreApples,
            scoreBananas = GameManager.Instance.ScoreBananas,
            globalTime = GameManager.Instance.GlobalTime
        };

        // Convertir a JSON
        string json = JsonUtility.ToJson(data, true);

        // Guardar en un archivo en persistentDataPath
        string path = Path.Combine(Application.persistentDataPath, "GameData.json");
        File.WriteAllText(path, json);

        Debug.Log($"Datos guardados en: {path}");
        Debug.Log($"JSON: {json}");

        // Opcional: Reanudar el juego o cerrar la aplicación
        // Time.timeScale = 1f; // Descomentar para reanudar
        // Application.Quit(); // Descomentar para cerrar el juego
    }
}