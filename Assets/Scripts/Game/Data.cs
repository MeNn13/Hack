using System;
using System.Collections;
using UnityEngine;

public class Data : MonoBehaviour
{
    public static Data Instance;
    public GameInfo GameInfo;

    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            Instance = this;
            Load();
        }
        else
            Destroy(gameObject);
    }

    private void Load()
    {
        GameInfo gameInfo;
        gameInfo = JsonUtility.FromJson<GameInfo>(PlayerPrefs.GetString("GameData"));

        if (gameInfo != null)
            GameInfo = gameInfo;
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(GameInfo);
        PlayerPrefs.SetString("GameData", json);
    }
}

[Serializable]
public class GameInfo
{
    public int Level = 1;
    public float MusicVolume = 1f;
    public float Sensitivity = 500f;
}
