using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveScore : MonoBehaviour
{
    protected static SaveScore instance;
    public static SaveScore Instance { get => instance; }
    private void Awake()
    {
        if (instance != null) Debug.Log("Only 1 ObjectSpawner allow");
        SaveScore.instance = this;
    }
    [System.Serializable]
    public class ScoreData
    {
        public int score;
    }
    public void SaveScoretoJson(int score)
    {
        string filePath = Application.persistentDataPath + "/score.json";
        ScoreData scoreData = new ScoreData
        {
            score = score
        };
        string json = JsonUtility.ToJson(scoreData);
        Debug.Log("Create New File");
        File.WriteAllText(filePath, json);
    }

    public int LoadScore()
    {
        string filePath = Application.persistentDataPath + "/score.json";

        if (!File.Exists(filePath))
        {
            Debug.Log("No data file exists");
            return 0;
        }
        string json = File.ReadAllText(filePath);
        ScoreData scoreData = JsonUtility.FromJson<ScoreData>(json);

        if (scoreData != null)
        {
            return scoreData.score;
        }
        else
        {
            Debug.LogError("Failed to parse score data from JSON");
            return 0; 
        }
    }
}
