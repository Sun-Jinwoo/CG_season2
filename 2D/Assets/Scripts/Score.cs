using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
  private float _score;
    private TextMeshProUGUI textMesh;
    private float _Score;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        _score = 0;
        //UpdateScoreText();
    }
    private void Update()
    {
        _score += Time.deltaTime;
        textMesh.text= _score.ToString("0");
       // UpdateScoreText();
    }
    public void Sumar_Score(float scoreEntrada)
    {
        _Score += scoreEntrada;
    }

}
