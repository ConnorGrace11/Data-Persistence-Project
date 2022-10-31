using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public string user;
    public int highScore = 0;

    // Start is called before the first frame update

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    public class HighScoreData
    {
        public string user;
        public int score;
    }
    
    public void SaveHighScore()
    {
        HighScoreData data = new HighScoreData();
        data.user = MenuManager.Instance.user;
        data.score = MenuManager.Instance.highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighScoreData data = JsonUtility.FromJson<HighScoreData>(json);

            user = data.user;
            highScore = data.score;

        }
        else
        {
            user = "N/A";
            highScore = 0;
        }
    }

    public void ResetHighScore()
    {
        HighScoreData data = new HighScoreData();
        data.user = "";
        data.score = 0;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

}
