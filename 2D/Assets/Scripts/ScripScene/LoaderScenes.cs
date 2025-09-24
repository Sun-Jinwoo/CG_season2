using UnityEngine;
using UnityEngine.SceneManagement;
public class LoaderScenes : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoaderScenesM(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}
