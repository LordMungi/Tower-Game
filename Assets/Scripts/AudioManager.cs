using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private AudioManager() { }

    public static AudioManager instance { get; private set; }

    [SerializeField] AudioSource ButtonClickSFX;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SetSounds();
    }

    private void SetSounds()
    {
        Button[] buttons = Resources.FindObjectsOfTypeAll<Button>();
        foreach (Button but in buttons)
        {
            but.onClick.AddListener(PlayButtonClickSFX);
        }
    }

    private void PlayButtonClickSFX()
    {
        ButtonClickSFX.Play();
    }
}
