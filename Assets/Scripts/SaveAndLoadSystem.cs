using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public static class SaveAndLoadSystem
{
    public static void saveData(int _musicVol, int _gameMusicVol, int _sdfxVol, int _sensitivity, int _highScore, int _diamonds, int _custItem)
    { 
        BinaryFormatter form = new BinaryFormatter();
        string path = Application.persistentDataPath + "/data.DONTTOUCHME";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(_musicVol, _gameMusicVol, _sdfxVol, _sensitivity, _highScore, _diamonds, _custItem);
        form.Serialize(stream, data);
        stream.Close();
    }
    public static PlayerData loadData()
    { 
        string path = Application.persistentDataPath + "/data.DONTTOUCHME";
        if (File.Exists(path))
        {
            BinaryFormatter form = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = form.Deserialize(stream) as PlayerData;
            if (data.highScore == null) { data.highScore = 0; }
            if (data.diamonds == null) { data.diamonds = 0; }
            stream.Close();
            return data;
        }

        else
        {
            PlayerData data = new PlayerData(80,50,80,60,0,0,0);
            return data;
        }
    }
}
