using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public enum ItemType
    {
        Apple,
        Banana
    }

    public ItemType type = ItemType.Apple;
    public int itemValue = 1;

    // Referencias para el panel y el temporizador
    [SerializeField] private GameOverPanel gameOverPanel;
    [SerializeField] private Timer tiempoEscena;

    void Start()
    {
        // Verificar asignaciones solo para el objeto "Goal"
        if (gameObject.CompareTag("Goal"))
        {
            if (gameOverPanel == null)
            {
                Debug.LogWarning($"gameOverPanel no está asignado en {gameObject.name}. Buscando GameOverPanel en la escena...");
                gameOverPanel = FindObjectOfType<GameOverPanel>();
                if (gameOverPanel == null)
                {
                    Debug.LogError("No se encontró GameOverPanel en la escena. Asigna manualmente en el Inspector.");
                }
            }
            if (tiempoEscena == null)
            {
                Debug.LogWarning($"tiempoEscena no está asignado en {gameObject.name}. Buscando Timer en la escena...");
                tiempoEscena = FindObjectOfType<Timer>();
                if (tiempoEscena == null)
                {
                    Debug.LogError("No se encontró Timer en la escena. Asigna manualmente en el Inspector.");
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (gameObject.CompareTag("Goal"))
            {
                // Colisión con la meta: detener el temporizador y mostrar el panel
                if (tiempoEscena != null && GameManager.Instance != null)
                {
                    tiempoEscena.TimerStop();
                    float getTimeScene = tiempoEscena.StopTime;
                    GameManager.Instance.TotalTime(getTimeScene);
                    Debug.Log($"Tiempo Escena 2 agregado: {GameManager.Instance.GlobalTime}");
                }
                else
                {
                    Debug.LogError("Error al procesar la meta: tiempoEscena o GameManager es null.");
                }

                // Mostrar el panel de fin de juego
                if (gameOverPanel != null)
                {
                    gameOverPanel.ShowGameOverPanel();
                }
                else
                {
                    Debug.LogError("gameOverPanel es null. No se puede mostrar el panel de fin de juego.");
                }
            }
            else
            {
                // Colisión con una fruta
                switch (type)
                {
                    case ItemType.Apple:
                        GameManager.Instance.TotalApples(itemValue);
                        break;
                    case ItemType.Banana:
                        GameManager.Instance.TotalBananas(itemValue);
                        break;
                }
                Destroy(gameObject); // Destruir la fruta
            }
        }
    }
}