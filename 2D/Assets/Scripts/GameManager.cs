using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    private float globalTime;
    private int ScoreApples=0;
    private int scoreBanana=0;


    void Awake()
    {
        
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
            
            Instance = this;
            DontDestroyOnLoad(gameObject);
          
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        globalTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TotalTime(float timeScene)
    {
        globalTime += timeScene;
    }
    public void TotalApples(int Apples)
    {
        ScoreApples += Apples;
    }
    public void TotalBanana(int Banana)
    {
        scoreBanana += Banana;
    }




    public float GlobalTime { get => globalTime; set => globalTime = value; }
    public int ScoreApples1 { get => ScoreApples; set => ScoreApples = value; }
    public int ScoreBanana { get => scoreBanana; set => scoreBanana = value; }
}
