using UnityEngine;

public class Pauser : MonoBehaviour
{
    [SerializeField] private float pauseDuration = 5f;
    public static Pauser Instance { get; private set; }
    public bool isPaused;
    private float pauseTimer;
    
    public void SetPause(bool pause)
    {
        isPaused = pause;
        Time.timeScale = pause ? 0f : 1f;
        if (pause) pauseTimer = 0f;
    }

    private void Update()
    {
        if (!isPaused) return;
        pauseTimer += Time.unscaledDeltaTime;
        if (pauseTimer >= pauseDuration) {SetPause(false); }

    }
    private void Awake()
    {
        if (Instance && Instance != this) Destroy(gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}