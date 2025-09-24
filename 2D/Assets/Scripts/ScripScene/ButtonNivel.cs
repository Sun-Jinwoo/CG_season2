using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonNivel : MonoBehaviour
{
 public int nivel;

public void CambiarNivel()
    {
        SceneManager.LoadScene(nivel);
    }
}
