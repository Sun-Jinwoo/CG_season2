using UnityEngine;

public class ControladorSonido : MonoBehaviour
{
    public static ControladorSonido Instance;
    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource no encontrado en ControladorSonido. Añade un componente AudioSource.");
        }
    }

    public void EjecutarSonido(AudioClip sonido)
    {
        if (audioSource != null && sonido != null)
        {
            audioSource.PlayOneShot(sonido);
        }
        else
        {
            Debug.LogWarning("AudioSource o sonido es null en ControladorSonido.");
        }
    }
}