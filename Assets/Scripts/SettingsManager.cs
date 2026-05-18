using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    private SettingsManager() { }
    public static SettingsManager instance { get; private set; }

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
}
