using System.IO;
using UnityEngine;

public class StoredData : MonoBehaviour
{
    public static StoredData Instance;

    public int Score;
    public string Name;
    public string BestName;

    //Keeps this object while deleting extra copies, also loads the data along with the scene
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadAll();
    }
    //Save data to keep
    [System.Serializable]
    class SaveData
    {
        public int Score;
        public string BestName;
    }
    //Exports the score and the name that got the score to a json
    public void SaveAll()
    {
        SaveData data = new SaveData();
        data.Score = Score;
        data.BestName = BestName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    //Imports the score and the name that got the score from a json
    public void LoadAll()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Score = data.Score;
            BestName = data.BestName;
        }
    }
}
