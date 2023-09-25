using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private static SaveManager _instance;
    public static SaveManager Instance => _instance;

    [SerializeField]
    private bool loadOnAwake = true;
    private string savefilePath;
    private void Awake()
    {
        savefilePath = Application.persistentDataPath + Path.DirectorySeparatorChar + "save.json";
        if (_instance == null)
            _instance = this;
        else
            Destroy(this);
    }

    private void Start()
    {
        if(loadOnAwake)
        {
            Load();
        }
    }

    private void Load()
    {
        if (!File.Exists(savefilePath))
            return;
        SaveFile sf = JsonUtility.FromJson<SaveFile>(File.ReadAllText(savefilePath));
        Inventory.Instance.Load(sf);
    }

    public void Save()
    {
        SaveFile saveFile = new SaveFile();
        Inventory.Instance.Save(saveFile);
        string jsonSave = JsonUtility.ToJson(saveFile);
        File.WriteAllText(savefilePath, jsonSave);
    }
}
