using System;
using System.Collections.Generic;
using UnityEngine;

public class TaskData : MonoBehaviour
{
    public static TaskData Instance { get; private set; }

    private List<string> _nameOfTask;
    private List<string> _descriptionOfTheTask;
    private List<DateTime> _startDate;
    private List<string> _startDateString;
    private List<DateTime> _endDate;
    private List<string> _endDateString;
    private List<GameData.Priority> _priority;
    private List<bool> _taskCompleted;
    
    private const string SaveKey = "MainSaveTasks";

    [SerializeField]
    private GameObject mainPanel;

    private void Awake()
    {
        Instance = this;
    }
    
    private void Start()
    {
        Load();
        SetStringToDate();
        mainPanel.SetActive(true);
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
        _startDateString = data.startDateString;
        _endDate = data.endDate;
        _endDateString = data.endDateString;
        _priority = data.priority;
        _taskCompleted = data.taskCompleted;

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
            startDateString = _startDateString,
            endDate = _endDate,
            endDateString = _endDateString,
            priority = _priority,
            taskCompleted = _taskCompleted
        };

        return data;
    }

    private void SetStringToDate()
    {
        for (int i = 0; i < _startDateString.Count; i++)
        {
            if (DateTime.TryParse(_startDateString[i], out DateTime result))
            {
                _startDate.Add(result);
            }
        }

        for (int i = 0; i < _endDate.Count; i++)
        {
            if (DateTime.TryParse(_endDateString[i], out DateTime result))
            {
                _endDate.Add(result);
            }
        }
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
        _startDateString.Add(date.ToString());
        Save();
    }

    public DateTime GetStartDate(int index)
    {
        return _startDate[index];
    }

    public void SetEndDate(DateTime date)
    {
        _endDate.Add(date);
        _endDateString.Add(date.ToString());
        Save();
    }

    public void SetPriority(GameData.Priority priority)
    {
        _priority.Add(priority);
        Save();
    }

    public void SetTaskCompleted(bool completed)
    {
        _taskCompleted.Add(completed);
        Save();
    }

    public bool GetTaskCompleted(int index)
    {
        return _taskCompleted[index];
    }

    public List<int> GetDailyTasksList()
    {
        List<int> listIndex = new List<int>();
        
        for (int i = 0; i < _startDate.Count; i++)
        {
            if (_startDate[i].Year == DateTime.Now.Year
                && _startDate[i].Month == DateTime.Now.Month
                && _startDate[i].Day == DateTime.Now.Day)
            {
                listIndex.Add(i);
            }
        }

        return listIndex;
    }
}
