using UnityEngine;
using UnityEngine.Events;

public class GameTimer : MonoBehaviour
{
    public static GameTimer Instance {get; private set;}

    private float startTime;
    private bool isRunning;

    public float ElapsedTime => isRunning ? Time.time - startTime : 0f;
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

    public void StartTimer()
    {
        startTime = Time.time;
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void ResetTimer()
    {
        startTime = Time.time;
    }

    public static string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        return $"{minutes:00}:{seconds:00}";
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isKill();
    }

    // if the current elapsed time of the game exceeds 5 minutes kill the application
    private void isKill()
    {
        if(Instance.ElapsedTime >= 300.0)
        {
            Debug.Log($"Game Over: Elapsed Time ${Instance.ElapsedTime}");
            Debug.Break();
            Application.Quit();
        }
    }
}
