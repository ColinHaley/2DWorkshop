using System;
using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

public class GameController : MonoBehaviour
{
    public enum DataFiles
    {
        PlayerData,
        LevelData
    }

    private DataFiles _dataFiles;
    public static GameController Controller;

    // Make a singelton model controller with a static reference.
    void Awake()
    {
        if (Controller == null)
        {
            DontDestroyOnLoad(gameObject);
            Controller = this;
        }
        else if (Controller != this)
        {
            Destroy(gameObject);
        }

        Save();
    }

    public void Save()
    {
        // Full save method. 
        var enumNames = Enum.GetNames(typeof(DataFiles));
        foreach (string enumName in enumNames)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/" + enumName + ".dat");

            SaveData data = new SaveData();

            //Set properties right here

            formatter.Serialize(file, data);
            file.Close();
        }
    }

    public void Save(DataFiles dataFile)
    {
        //Specific save file. 
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + dataFile + ".dat");

        SaveData data = new SaveData();

        //Set properties right here

        formatter.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        // Full Load
        var enumNames = Enum.GetNames(typeof(DataFiles));
        foreach (string enumName in enumNames)
        {
            if (File.Exists(Application.persistentDataPath + "/" + enumName + ".dat"))
            {
                
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/" + enumName + ".dat", FileMode.Open);

                SaveData data = (SaveData) formatter.Deserialize(file);
                file.Close();

                //set properties
            }
        }
    }
}


[Serializable]
class SaveData
{
    //Placeholder for data to save.
}