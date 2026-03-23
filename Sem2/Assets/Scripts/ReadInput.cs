using UnityEngine;

public class ReadInput : MonoBehaviour
{
    public string playerName;

    public void ReadStringInput ( string s)
    {
        GameManager.instance.saveDataSO.saveData.playerName = s;
        Debug.Log(playerName);
    }
}
