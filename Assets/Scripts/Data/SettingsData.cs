using UnityEngine;

public class SettingsData : MonoBehaviour
{
    public static SettingsData Instance { get; private set; }
    
    private bool[] _calendarType;
    private bool _pushNotifications;
    private bool _sounds;

    private const string SaveKey = "MainSaveSettings";

    private int _monthCalendarIndex = 0;
    private int _weekCalendarIndex = 1;
    
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
        
        _calendarType = data.calendarType;
        _pushNotifications = data.pushNotifications;
        _sounds = data.sounds = AudioManager.Instance.GetSound();
        
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
            calendarType = _calendarType,
            pushNotifications = _pushNotifications,
            sounds = _sounds = AudioManager.Instance.GetSound()
        };

        return data;
    }

    public bool GetPushNotification()
    {
        return _pushNotifications;
    }

    public void SetPushNotification()
    {
        _pushNotifications = !_pushNotifications;
        Save();
    }

    public bool GetSound()
    {
        return _sounds;
    }

    public void SetSound()
    {
        _sounds = !_sounds;
        Save();
    }

    public int GetCalendarTypeIndex()
    {
        for (int i = 0; i < _calendarType.Length; i++)
        {
            if (_calendarType[i])
            {
                return i;
                break;
            }
        }

        return 0;
    }

    public int GetMonthCalendarIndex()
    {
        return _monthCalendarIndex;
    }

    public int GetWeekCalendarIndex()
    {
        return _weekCalendarIndex;
    }

    public void SetCalendarTypeIndex(int currentIndex)
    {
        for (int i = 0; i < _calendarType.Length; i++)
        {
            if (i == currentIndex)
            {
                _calendarType[i] = true;
            }
            else
            {
                _calendarType[i] = false;
            }
        }
    }
}
