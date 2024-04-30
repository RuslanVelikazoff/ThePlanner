using System;
using System.Collections.Generic;
using UnityEngine;

public class TaskData : MonoBehaviour
{
    public static TaskData Instance { get; private set; }

    private List<string> _nameOfTask;
    private List<string> _descriptionOfTheTask;
    private List<DateTime> _startDate;
    private List<DateTime> _endDate;
    private List<GameData.Priority> _priority;
    
    private const string SaveKey = "MainSaveTasks";

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

        _nameOfTask = data.nameOfTask;
        _descriptionOfTheTask = data.descriptionOfTheTask;
        _startDate = data.startDate;
        _endDate = data.endDate;
        _priority = data.priority;

        Debug.Log("Tasks Data Load");
    }

    private void Save()
    {
        SaveManager.Save(SaveKey, GetSaveSnapshot());
        PlayerPrefs.Save();
        
        Debug.Log("Tasks Data Save");
    }

    private GameData GetSaveSnapshot()
    {
        var data = new GameData()
        {
            nameOfTask = _nameOfTask,
            descriptionOfTheTask = _descriptionOfTheTask,
            startDate = _startDate,
            endDate = _endDate,
            priority = _priority
        };

        return data;
    }

    public void SetNameOfTask(string name)
    {
        _nameOfTask.Add(name);
        Save();
    }

    public void SetDescriptionOfTheTask(string description)
    {
        _descriptionOfTheTask.Add(description);
        Save();
    }

    public void SetStartDate(DateTime date)
    {
        _startDate.Add(date);
        Save();
    }

    public void SetEndDate(DateTime date)
    {
        _endDate.Add(date);
        Save();
    }

    public void SetPriority(GameData.Priority priority)
    {
        _priority.Add(priority);
        Save();
    }
}
