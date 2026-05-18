using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameConfig config;

    [Header("Broadcast Events")]
    [SerializeField] private EventChannel BlockCreateEvent;
    [SerializeField] private EventChannel BlockDropEvent;
    [SerializeField] private IntEventChannel UpdateFloorsEvent;
    [SerializeField] private IntEventChannel UpdateStreakEvent;
    [SerializeField] private IntEventChannel UpdateScoreEvent;
    [SerializeField] private IntEventChannel UpdateLivesEvent;

    [Header("Listener Events")]
    [SerializeField] private BlockEventChannel BlockSuccessfulLandEvent;
    [SerializeField] private BlockEventChannel BlockPerfectLandEvent;
    [SerializeField] private BlockEventChannel BlockFailedLandEvent;
    [SerializeField] private BlockEventChannel BlockMissedLandEvent;

    private int towerHeight;
    private int perfectStreak;
    private int score;
    private int lives;

    private void Awake()
    {
        towerHeight = 0;
        perfectStreak = 0;
        score = 0;
        lives = config.InitialLives;
    }
    void Start()
    {
        BlockCreateEvent.RaiseEvent();
    }

    private void OnEnable()
    {
        BlockSuccessfulLandEvent.OnEventTriggered += OnBlockLand;
        BlockPerfectLandEvent.OnEventTriggered += OnBlockPerfectLand;
        BlockFailedLandEvent.OnEventTriggered += OnBlockFail;
        BlockMissedLandEvent.OnEventTriggered += OnBlockMiss;
    }
    private void OnDisable()
    {
        BlockSuccessfulLandEvent.OnEventTriggered -= OnBlockLand;
        BlockPerfectLandEvent.OnEventTriggered -= OnBlockPerfectLand;
        BlockFailedLandEvent.OnEventTriggered -= OnBlockFail;
        BlockMissedLandEvent.OnEventTriggered -= OnBlockMiss;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            BlockDropEvent.RaiseEvent();
    }

    private void OnBlockLand(Block b)
    {
        UpdateHeight(1);
        UpdateScore(config.ScoreForFloor);
        RemoveStreak();
    }
    private void OnBlockPerfectLand(Block b)
    {
        UpdateHeight(1);
        UpdateScore(config.ScoreForPerfect);
        perfectStreak += 1;
        UpdateStreakEvent.RaiseEvent(perfectStreak);
    }

    private void OnBlockFail(Block b)
    {
        if (towerHeight > 1)
            UpdateHeight(-1);
        RemoveStreak();
        LoseLife();
    }

    private void OnBlockMiss(Block b)
    {
        RemoveStreak();
        LoseLife();
    }

    private void UpdateHeight(int addition)
    {
        towerHeight += addition;
        UpdateFloorsEvent.RaiseEvent(towerHeight);
    }

    private void UpdateScore(int addition)
    {
        score += addition;
        UpdateScoreEvent.RaiseEvent(score);
    }

    private void RemoveStreak()
    {
        perfectStreak = 0;
        UpdateStreakEvent.RaiseEvent(perfectStreak);
    }

    private void LoseLife()
    {
        lives--;
        UpdateLivesEvent.RaiseEvent(lives);
    }
}
