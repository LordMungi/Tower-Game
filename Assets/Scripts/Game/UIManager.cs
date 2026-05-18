using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameConfig gameConfig;

    [Header("Assets")]
    [SerializeField] private TextMeshProUGUI heightText;
    [SerializeField] private TextMeshProUGUI perfectText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Canvas livesCanvas;
    [SerializeField] private GameObject livesPrefab;

    [Header("Listener Events")]
    [SerializeField] private IntEventChannel UpdateFloorsEvent;
    [SerializeField] private IntEventChannel UpdateStreakEvent;
    [SerializeField] private IntEventChannel UpdateScoreEvent;
    [SerializeField] private IntEventChannel UpdateLivesEvent;

    private Stack<GameObject> LiveStack;

    private void Awake()
    {
        heightText.text = "Floors: 0";
        perfectText.gameObject.SetActive(false);
        scoreText.text = "0";

        LiveStack = new Stack<GameObject>();
        for (int i = 0; i < gameConfig.InitialLives; i++)
        {
            LiveStack.Push(Instantiate(livesPrefab, livesCanvas.transform));
        }
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }


}
