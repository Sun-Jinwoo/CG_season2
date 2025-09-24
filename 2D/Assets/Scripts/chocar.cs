using UnityEngine;

public class chocar : MonoBehaviour
{
  public GameObject Panel;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Panel.SetActive(true);
            Time.timeScale = 0f; // Pausa el juego
        }
    }
}
