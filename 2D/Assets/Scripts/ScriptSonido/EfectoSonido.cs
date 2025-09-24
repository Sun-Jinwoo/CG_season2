using UnityEngine;

public class EfectoSonido : MonoBehaviour
{
    [SerializeField] private AudioClip colectar1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (ControladorSonido.Instance != null && colectar1 != null)
            {
                ControladorSonido.Instance.EjecutarSonido(colectar1);
            }
            else
            {
                Debug.LogWarning($"ControladorSonido.Instance o colectar1 es null en {gameObject.name}");
            }
        }
    }
}