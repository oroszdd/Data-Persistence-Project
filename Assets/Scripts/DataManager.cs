using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string playerName;
    public int score;
    public string highscorePlayerName;
    public int highscoreScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    class SaveData
    {
        public string highscorePlayerName;
        public int highscoreScore;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.highscorePlayerName = highscorePlayerName;
        data.highscoreScore = highscoreScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highscorePlayerName = data.highscorePlayerName;
            highscoreScore = data.highscoreScore;
        }
    }
}
