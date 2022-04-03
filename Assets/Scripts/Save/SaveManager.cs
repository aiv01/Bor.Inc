using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveManager
{
    public static string directory = "/SaveData/";
    public static string filename = "MyData.txt";
    public static void Save(SaveObject so) {
        //if (!DirectoryExixts())
        //    Directory.CreateDirectory(Application.persistentDataPath + "/" + directory);
        //BinaryFormatter bf = new BinaryFormatter();
        //FileStream file = File.Create(GetFullPath());
        //bf.Serialize(file, so);
        //file.Close();

        string dir = Application.persistentDataPath + directory;
        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);
        string json = JsonUtility.ToJson(so);
        File.WriteAllText(dir + filename, json);
    }
    private static SaveObject Load() {

        //if (SaveExists()) {
        //    try {
        //        BinaryFormatter bf = new BinaryFormatter();
        //        FileStream file = File.Open(GetFullPath(), FileMode.Open);
        //        SaveObject so = (SaveObject)bf.Deserialize(file);
        //        file.Close();
        //        return so;
        //    }
        //    catch (SerializationException) {
        //        Debug.Log("File Currupted");
        //    }
        //}
        //return null;


        string fullpath = Application.persistentDataPath + directory + filename;
        SaveObject so = new SaveObject();

        if (File.Exists(fullpath)) {
            string json = File.ReadAllText(fullpath);
            so = JsonUtility.FromJson<SaveObject>(json);
        } else {
            Debug.Log("Save file does not exist");
        }
        return so;
    }
    public static void SaveStaticClassValues() {
        SaveObject so = new SaveObject();
        so.collectedBundles = ScriptableStaticClass.instance.GetCollectedItems();
        so.inInventory = ScriptableStaticClass.instance.GetInInventoryItems();
        so.nKeys = ScriptableStaticClass.instance.nKeys;
        so.level = ScriptableStaticClass.instance.level;
        so.explorerNumber = ScriptableStaticClass.instance.explorerNumber;
        SaveManager.Save(so);
    }
    public static void LoadSave() {
        SaveObject so = SaveManager.Load();
        ScriptableStaticClass.instance.SetCollectedItems(so.collectedBundles);
        ScriptableStaticClass.instance.SetInInventoryItems(so.inInventory);
        ScriptableStaticClass.instance.nKeys = so.nKeys;
        ScriptableStaticClass.instance.level = so.level;
        ScriptableStaticClass.instance.explorerNumber = so.explorerNumber;
    }
    private static bool SaveExists() {
        return File.Exists(GetFullPath());
    }
    private static bool DirectoryExixts() {
        return Directory.Exists(Application.persistentDataPath + "/" + directory);
    }
    private static string GetFullPath() {
        return Application.persistentDataPath + "/" + directory + "/" + filename;
    }
}
