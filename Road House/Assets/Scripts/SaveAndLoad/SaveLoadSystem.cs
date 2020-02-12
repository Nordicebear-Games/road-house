﻿using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoadSystem
{
    public static void SaveGameData(Game gameManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, "game.fun");
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData gameData = new GameData(gameManager);

        formatter.Serialize(stream, gameData);
        stream.Close();
    }

    public static GameData LoadGameData()
    {
        string path = Path.Combine(Application.persistentDataPath, "game.fun");

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData gameData = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return gameData;
        }
        else
        {
            //Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static void DeleteDatas()
    {
        File.Delete(Application.persistentDataPath + "/game.fun");
    }
}
