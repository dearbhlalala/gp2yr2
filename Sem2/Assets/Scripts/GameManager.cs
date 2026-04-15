using System.IO;
using UnityEditor.Overlays;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SaveDataScriptableObject saveDataSO;
    public static GameManager instance;
    const string FILE_NAME = "SaveData.json";
    string filePath;
    public Transform playerTransform;

    private void Awake()
    {
        instance = this;
        LoadGame(); 
        Debug.Log(filePath);
    }

    void SaveGame()
    {
        string saveDataJson = JsonUtility.ToJson(saveDataSO.saveData);
        File.WriteAllText(filePath + "/" + FILE_NAME, saveDataJson);
    }

    void LoadGame()
    {
        filePath = Application.persistentDataPath;

        if(File.Exists(filePath + "/" + FILE_NAME))
        {
            string loadedJson = File.ReadAllText(filePath + "/" + FILE_NAME);
            saveDataSO.saveData = JsonUtility.FromJson<SaveData>(loadedJson);
            playerTransform.position = saveDataSO.saveData.playerPosition;
        }
        else
        {
            saveDataSO.saveData = new SaveData
            {
                playerPosition = new Vector3(7.82999992f, -1.78813934e-07f, -1.71000004f),
                enemyPosition = new Vector3(-2.91261697f, 2.38418579e-07f, -4.55461788f),
                doorOpenCount = 0,
                playerName = null
            };
        }
    }

    void OnApplicationQuit()
    {
        saveDataSO.saveData.playerPosition = playerTransform.position;
        Debug.Log(saveDataSO.saveData.playerPosition);
        SaveGame(); 
    }

    void OnApplicationPause(bool pause)
    {
        saveDataSO.saveData.playerPosition = playerTransform.position;
        Debug.Log(saveDataSO.saveData.playerPosition);
        if (pause)
        {
            SaveGame();
        }
    }
}
