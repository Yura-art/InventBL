using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] GameData _gameData;

    string filePath;

    public GameData GameData { get => _gameData; set => _gameData = value; }

    private void Awake()
    {
        filePath = Application.persistentDataPath + "/GameData";
        Debug.Log(filePath);

        CheckData();
    }

    public void CheckData()
    {
        if (!File.Exists(filePath))
        {
            File.CreateText(filePath).Close();
            SaveData();
        }
        else
        {
            LoadData();
        }
        
    } 

    public void SaveData()
    {     

        string json=JsonUtility.ToJson(GameData);

        File.WriteAllText(filePath, json);

    }

    public void LoadData()
    {
        string json = File.ReadAllText(filePath);

        _gameData = JsonUtility.FromJson<GameData>(json);
    }
}
