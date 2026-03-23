using UnityEngine;


public struct SaveData
{
    public Vector3 playerPosition;
    public Vector3 enemyPosition;
    public int doorOpenCount;

}

[CreateAssetMenu(fileName = "SaveData", menuName = "ScriptableObjects/SaveData", order = 1)]

public class SaveDataScriptableObject : ScriptableObject
{
    public SaveData saveData;


    void SetInitialSaveDataValues()
    {
        saveData.playerPosition = new Vector3(7.82999992f, -1.78813934e-07f, -1.71000004f);
        saveData.enemyPosition = new Vector3(-2.91261697f, 2.38418579e-07f, -4.55461788f);

        saveData.doorOpenCount = 0;
    }
}
