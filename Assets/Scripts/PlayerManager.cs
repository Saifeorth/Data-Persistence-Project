using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public string playerName;
    public string previousBestPlayerName;
    public int playerBestScore;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadPlayerName();
        LoadBestScore();

    }


    [System.Serializable]
    class SaveData
    {
        public string playerName;

    }

    [System.Serializable]
    class PreviousPlayerData 
    {
        public int playerBestScore;
        public string previousBestPlayerName;
        
    }

    public void SavePlayerName()
    {
        SaveData data = new SaveData();

        data.playerName = playerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayerName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
        }
    }





    public void SaveBestScore(int score, string Name)
    {
        PreviousPlayerData data = new PreviousPlayerData();

        data.playerBestScore = score;
        data.previousBestPlayerName = Name;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savePreviousfile.json", json);
    }



    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savePreviousfile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PreviousPlayerData data = JsonUtility.FromJson<PreviousPlayerData>(json);

            playerBestScore = data.playerBestScore;
            previousBestPlayerName = data.previousBestPlayerName;
        }
    }




}
