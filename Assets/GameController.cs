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
            FileStream file = File.Open(Application.persistentDataPath + "/" + enumName + ".dat", FileMode.Create);
            
        }
    }

    public void Save(string test)
    {
        //Specific save file. How do I get the name of the enum specifically instead of looping?
        

    }
}

class SaveData
{
    //Placeholder for data to save.
}