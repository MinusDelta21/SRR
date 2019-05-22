using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public class PlayerData : ScriptableObject
{
    string nickname;
    uint money;

    public uint Money
    {
        get { return money; }
        set { money = value; }
    }
    /// <summary>
    /// Save this object
    /// </summary>
    public void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Player_Data/" + nickname;

        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, this);
        stream.Close();

    }
    /// <summary>
    /// Load this object
    /// </summary>
    public void Load()
    {
        string path = Application.persistentDataPath + "/SC_Data/" + name;


        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            this.nickname = data.nickname;
            this.money = data.money;
            
        }
    }
}
