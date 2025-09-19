//using UnityEngine;
//using TMPro;
//public class GameCointrollerScene1 : MonoBehaviour
//{

//    public Timer tiempoEscena;
//    public TMPro.TextMeshProUGUI textApple;
//    public TMPro.TextMeshProUGUI textBanana;

//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if(GameManager.Instance!=null)
//        {
//           int apples= GameManager.Instance.ScoreApples1;
//           int banana= GameManager.Instance.ScoreBanana;

//            textApple.text= apples.ToString();
//            textBanana.text= banana.ToString();
//        }
//    }

//    public void AddTime()
//    {
//        tiempoEscena.TimerStop();
//        float getTimeScene= tiempoEscena.StopTime;

//        GameManager.Instance.TotalTime(getTimeScene);

//        Debug.Log("Tiempo Escena 1" + GameManager.Instance.GlobalTime);
//    }

//}

using UnityEngine;
using TMPro;

public class GameCointrollerScene1 : MonoBehaviour
{
    public Timer tiempoEscena;
    public TextMeshProUGUI textApple;
    public TextMeshProUGUI textBanana;

    void Start()
    {
        // Puedes agregar inicialización aquí si es necesario, como verificar si GameManager existe
    }

    void Update()
    {
        if (GameManager.Instance != null)
        {
            int apples = GameManager.Instance.ScoreApples;  // Corregido: ScoreApples1 -> ScoreApples
            int bananas = GameManager.Instance.ScoreBananas; // Corregido: ScoreBanana -> ScoreBananas

            textApple.text = apples.ToString();
            textBanana.text = bananas.ToString();
        }
        else
        {
            // Opcional: Agregar un mensaje de debug si GameManager no existe
            Debug.LogWarning("GameManager no encontrado en la escena. Asegúrate de que esté en la escena inicial.");
        }
    }

    public void AddTime()
    {
        tiempoEscena.TimerStop();
        float getTimeScene = tiempoEscena.StopTime;

        GameManager.Instance.TotalTime(getTimeScene);

        Debug.Log("Tiempo Escena 1: " + GameManager.Instance.GlobalTime);
    }
}
