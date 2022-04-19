using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerStats : MonoBehaviour
{
    private PlayerData playerData;
    private int coins;
    public string path;
    // Start is called before the first frame update
    void Start()
    {
        path = Application.persistentDataPath + "/save.save";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RecieveCoins()
    {
        SaveData();
    }

    public void LoadData()
    {
        using (StreamReader reader = new StreamReader(path))
        {
            string json = reader.ReadToEnd();
            playerData = JsonUtility.FromJson<PlayerData>(json);
            coins = playerData.Coins; // event update ui
        }
    }

    public void SaveData()
    {
        if (playerData == null)
        {
            playerData = new PlayerData();
            playerData.Coins = coins;

            string jsonString = JsonUtility.ToJson(playerData);
            Debug.Log("Json" + jsonString);

            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.Write(jsonString);
            }
        }
    }
}

[System.Serializable]
public class PlayerData
{
    public int Coins;
}
