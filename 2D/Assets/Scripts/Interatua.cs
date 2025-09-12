using UnityEngine;
using UnityEngine.SceneManagement;
public class Interatua : MonoBehaviour
{
   public int nivel;
    public GameObject Texto;

    private bool lugar;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && lugar == true)
        {
            SceneManager.LoadScene(nivel);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Palyer")
        {
            Texto.SetActive(true);
            lugar = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Palyer")
        {
            Texto.SetActive(false);
            lugar = false;
        }
    }
}
