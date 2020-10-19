using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem 
{
    public static void SavePlayer (Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer ()
    {
        string path = Application.persistentDataPath + "/player.data";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        } else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }
    

    public static void SaveData (Saving saving)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/shop.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        Data data = new Data(saving);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static Data LoadData ()
    {
        string path = Application.persistentDataPath + "/shop.data";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Data data = formatter.Deserialize(stream) as Data;
            stream.Close();

            return data;
        } else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }

}
