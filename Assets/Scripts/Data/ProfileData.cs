using System;
using UnityEngine;

public class ProfileData : MonoBehaviour
{
    public static ProfileData Instance { get; private set; }

    private string _firstName;
    private string _lastName;
    private string _emailAddress;
    private int _age;
    private bool[] _gender;

    private int _maleGenderIndex = 0;
    private int _femaleGenderIndex = 1;
    private int _otherGenderIndex = 2;
    
    private const string SaveKey = "MainSaveProfile";

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
            gender = _gender
        };

        return data;
    }

    public string GetFirstName()
    {
        return _firstName;
    }

    public void SetFirstName(string newFirstName)
    {
        _firstName = newFirstName;
    }

    public string GetLastName()
    {
        return _lastName;
    }

    public void SetLastName(string newLastName)
    {
        _lastName = newLastName;
    }

    public string GetEmailAddress()
    {
        return _emailAddress;
    }

    public void SetEmailAddress(string newEmailAddress)
    {
        _emailAddress = newEmailAddress;
    }

    public int GetAge()
    {
        return _age;
    }

    public void SetAge(int newAge)
    {
        _age = newAge;
    }

    public int? GetActiveGenderIndex()
    {
        for (int i = 0; i < _gender.Length; i++)
        {
            if (_gender[i])
            {
                return i;
                break;
            }
        }

        return null;
    }

    public void SetGender(int newIndex)
    {
        for (int i = 0; i < _gender.Length; i++)
        {
            if (i == newIndex)
            {
                _gender[i] = true;
            }
            else
            {
                _gender[i] = false;
            }
        }
    }

    public bool SaveNewProfile()
    {
        if (GetFirstName() != string.Empty
            && GetLastName() != string.Empty
            && GetEmailAddress() != string.Empty
            && GetActiveGenderIndex() != null)
        {
            Save();
            return true;
        }
        else
        {
            return false;
        }
    }

    public int GetMaleIndex()
    {
        return _maleGenderIndex;
    }

    public int GetFemaleIndex()
    {
        return _femaleGenderIndex;
    }

    public int GetOtherIndex()
    {
        return _otherGenderIndex;
    }
}
