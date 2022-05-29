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

    public Player player;
    public FloatingText floatingText;

    public GameState gameState;


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
