using UnityEngine;

public class EfectoSonido : MonoBehaviour
{

    private AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // This function is called when the Collider2D other enters the trigger (2D physics only).
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioSource.Play();
        }
    }
}
