using TMPro;
using UnityEngine;

public class GameCointrollerScene2 : MonoBehaviour
{
    public Timer tiempoEscena;
    public TextMeshProUGUI textApple;
    public TextMeshProUGUI textBanana;

    void Start()
    {
        // Verificar asignaciones
        if (textApple == null)
        {
            Debug.LogError("textApple NO est� asignado en GameCointrollerScene2. Crea un TextMeshProUGUI en el Canvas y as�gnalo en el Inspector.");
        }
        if (textBanana == null)
        {
            Debug.LogError("textBanana NO est� asignado en GameCointrollerScene2. Crea un TextMeshProUGUI en el Canvas y as�gnalo en el Inspector.");
        }
        if (tiempoEscena == null)
        {
            Debug.LogWarning("tiempoEscena no est� asignado. El timer no funcionar�.");
        }
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager.Instance es null. Inicia el juego desde la escena que contiene el GameManager.");
        }
    }

    void Update()
    {
        if (GameManager.Instance != null && textApple != null && textBanana != null)
        {
            int apples = GameManager.Instance.ScoreApples;
            int bananas = GameManager.Instance.ScoreBananas;

            textApple.text = apples.ToString();
            textBanana.text = bananas.ToString();
        }
        else
        {
            if (GameManager.Instance == null)
            {
                Debug.LogWarning("GameManager no encontrado. Verifica que DontDestroyOnLoad est� activo.");
            }
            if (textApple == null)
            {
                Debug.LogWarning("textApple es null - No se puede actualizar el texto de manzanas.");
            }
            if (textBanana == null)
            {
                Debug.LogWarning("textBanana es null - No se puede actualizar el texto de bananas.");
            }
        }
    }

    public void AddTime()
    {
        if (tiempoEscena != null && GameManager.Instance != null)
        {
            tiempoEscena.TimerStop();
            float getTimeScene = tiempoEscena.StopTime;

            GameManager.Instance.TotalTime(getTimeScene);

            Debug.Log("Tiempo Escena 2 agregado: " + GameManager.Instance.GlobalTime);
        }
        else
        {
            Debug.LogError("Error en AddTime: tiempoEscena o GameManager es null.");
        }
    }
}