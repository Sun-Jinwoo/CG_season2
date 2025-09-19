//using UnityEngine;

//public class GameManager : MonoBehaviour
//{

//    public static GameManager Instance;

//    private float globalTime;
//    private int ScoreApples=0;
//    private int scoreBanana=0;


//    void Awake()
//    {

//        if(Instance != null && Instance != this)
//        {
//            Destroy(gameObject);
//            return;
//        }

//            Instance = this;
//            DontDestroyOnLoad(gameObject);

//    }

//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    void Start()
//    {
//        globalTime = 0;
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    public void TotalTime(float timeScene)
//    {
//        globalTime += timeScene;
//    }
//    public void TotalApples(int Apples)
//    {
//        ScoreApples += Apples;
//    }
//    public void TotalBanana(int Banana)
//    {
//        scoreBanana += Banana;
//    }




//    public float GlobalTime { get => globalTime; set => globalTime = value; }
//    public int ScoreApples1 { get => ScoreApples; set => ScoreApples = value; }
//    public int ScoreBanana { get => scoreBanana; set => scoreBanana = value; }
//}


using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private float globalTime;
    private int scoreApples = 0;
    private int scoreBananas = 0;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        globalTime = 0;
    }

    public void TotalTime(float timeScene)
    {
        globalTime += timeScene;
    }

    public void TotalApples(int apples)
    {
        scoreApples += apples;
    }

    public void TotalBananas(int bananas)
    {
        scoreBananas += bananas;
    }

    public float GlobalTime { get => globalTime; set => globalTime = value; }
    public int ScoreApples { get => scoreApples; set => scoreApples = value; }
    public int ScoreBananas { get => scoreBananas; set => scoreBananas = value; }
}
