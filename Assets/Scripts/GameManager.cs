using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private const string SAVE_STATE = "SaveState";


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    // Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    [SerializeField]
    private Player player;
    [SerializeField]
    private FloatingTextManager floatingTextManager;

    public GameState gameState;


    public void ShowText(string message, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(message, fontSize, color, position, motion, duration);
    }

    public void SaveState()
    {
        Debug.Log("save state");

        string jsonState = JsonUtility.ToJson(this.gameState);
        PlayerPrefs.SetString(SAVE_STATE, jsonState);
    }
    public void LoadState(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("load state");

        if (!PlayerPrefs.HasKey(SAVE_STATE))
        {
            this.gameState = new GameState();
            return;
        }

        string jsonState = PlayerPrefs.GetString(SAVE_STATE);

        this.gameState = JsonUtility.FromJson<GameState>(jsonState);
    }
}
