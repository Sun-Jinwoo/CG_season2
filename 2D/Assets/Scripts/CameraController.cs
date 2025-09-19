using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform objetivo; // El objeto que la c�mara seguir� al jugador
    public float velocidadCamara = 0.025f; // La velocidad de seguimiento de la camara
    public Vector3 desplazamiento; // Desplazamiento de la c�mara con respecto al jugador

    private void LateUpdate()
    {
        
        {
            Vector3 posicionDeseada = objetivo.position + desplazamiento;
            Vector3 posicionSuavizada = Vector3.Lerp(transform.position, posicionDeseada, velocidadCamara);
            transform.position = posicionSuavizada;
        }
    }
}
