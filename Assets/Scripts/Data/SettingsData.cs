using System;
using UnityEngine;

public class SettingsData : MonoBehaviour
{
    public static SettingsData Instance { get; private set; }

    private string _firstName;
    private string _lastName;
    private string _emailAddress;
    private int _age;
    private string _gender;
    private bool _pushNotifications;
    private bool _sounds;

    private const string SaveKey = "MainSave";
    
    private void Awake()
    {
        Instance = this;
    }
    
    private void Start()
    {
        Load();
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            Save();
        }
    }

    private void OnDisable()
    {
        Save();
    }

    private void Load()
    {
        var data = SaveManager.Load<GameData>(SaveKey);

        _firstName = data.firstName;
        _lastName = data.lastName;
        _emailAddress = data.emailAddress;
        _age = data.age;
        _gender = data.gender;
        _pushNotifications = data.pushNotifications;
        _sounds = data.sounds;
        
        Debug.Log("Settings Data Load");
    }

    private void Save()
    {
        SaveManager.Save(SaveKey, GetSaveSnapshot());
        PlayerPrefs.Save();
        
        Debug.Log("Settings Data Save");
    }

    private GameData GetSaveSnapshot()
    {
        var data = new GameData()
        {
            firstName = _firstName,
            lastName = _lastName,
            emailAddress = _emailAddress,
            age = _age,
            gender = _gender,
            pushNotifications = _pushNotifications,
            sounds = _sounds
        };

        return data;
    }
}
