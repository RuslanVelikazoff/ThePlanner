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
    private List<GameData.Category> _category;
    private List<bool> _taskCompleted;
    private List<bool> _favourite;
    private List<bool> _notification;
    
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
        SetStartDateInStart();
        Save();
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
        _category = data.category;
        _taskCompleted = data.taskCompleted;
        _favourite = data.favourite;
        _notification = data.notification;
    }

    private void Save()
    {
        SaveManager.Save(SaveKey, GetSaveSnapshot());
        PlayerPrefs.Save();
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
            category = _category,
            taskCompleted = _taskCompleted,
            favourite = _favourite,
            notification = _notification
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

        for (int i = 0; i < _endDateString.Count; i++)
        {
            if (DateTime.TryParse(_endDateString[i], out DateTime result))
            {
                _endDate.Add(result);
            }
        }
    }

    private void SetStartDateInStart()
    {
        for (int i = 0; i < _startDate.Count; i++)
        {
            if (DateTime.Now <= _endDate[i] && DateTime.Now >= _startDate[i])
            {
                _startDate[i] = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            }
        }
    }

    public void SetNameOfTask(string name)
    {
        _nameOfTask.Add(name);
        Save();
    }

    public string GetNameOfTask(int index)
    {
        return _nameOfTask[index];
    }

    public void SetDescriptionOfTheTask(string description)
    {
        _descriptionOfTheTask.Add(description);
        Save();
    }

    public string GetDescriptionOfTheTask(int index)
    {
        return _descriptionOfTheTask[index];
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

    public GameData.Priority GetPriority(int index)
    {
        return _priority[index];
    }
    
    public List<int> GetPriorityTasksList(GameData.Priority priority)
    {
        List<int> listIndex = new List<int>();
        
        for (int i = 0; i < _priority.Count; i++)
        {
            if (_priority[i] == priority)
            {
                listIndex.Add(i);
            }
        }

        return listIndex;
    }

    public void SetCategory(GameData.Category category)
    {
        _category.Add(category);
        Save();
    }

    public GameData.Category GetCategory(int index)
    {
        return _category[index];
    }

    public List<int> GetCategoryTasksList(GameData.Category category)
    {
        List<int> listIndex = new List<int>();
        
        for (int i = 0; i < _category.Count; i++)
        {
            if (_category[i] == category)
            {
                listIndex.Add(i);
            }
        }

        return listIndex;
    }
    
    public void SetTaskCompleted(bool completed)
    {
        _taskCompleted.Add(completed);
        Save();
    }

    public void TaskCompleted(int index)
    {
        _taskCompleted[index] = true;
    }

    public bool GetTaskCompleted(int index)
    {
        return _taskCompleted[index];
    }

    public void SetFavourite(bool favourite)
    {
        _favourite.Add(favourite);
        Save();
    }

    public void TaskFavourite(int index, bool favourite)
    {
        _favourite[index] = favourite;
        Save();
    }

    public bool GetTaskFavourite(int index)
    {
        return _favourite[index];
    }

    public void SetNotification(bool notification)
    {
        _notification.Add(notification);
    }

    public void TaskNotification(int index, bool notification)
    {
        _notification[index] = notification;
        Save();
    }

    public bool GetTaskNotification(int index)
    {
        return _notification[index];
    }
    
    public List<int> GetNotificationTasksList()
    {
        List<int> listIndex = new List<int>();
        
        for (int i = 0; i < _notification.Count; i++)
        {
            if (_notification[i] == true)
            {
                listIndex.Add(i);
            }
        }

        return listIndex;
    }

    public List<int> GetFavoriteTasksList()
    {
        List<int> listIndex = new List<int>();
        
        for (int i = 0; i < _favourite.Count; i++)
        {
            if (_favourite[i] == true)
            {
                listIndex.Add(i);
            }
        }

        return listIndex;
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

    public List<int> GetAllTasksList()
    {
        List<int> listIndex = new List<int>();

        for (int i = 0; i < _taskCompleted.Count; i++)
        {
            listIndex.Add(i);
        }

        return listIndex;
    }

    public List<int> GetDateTaskList(DateTime date)
    {
        List<int> listIndex = new List<int>();

        for (int i = 0; i < _startDate.Count; i++)
        {
            if (_startDate[i].Year == date.Year
                && _startDate[i].Month == date.Month
                && _startDate[i].Day == date.Day)
            {
                listIndex.Add(i);
            }
        }

        return listIndex;
    }

    public void DeleteTask(int index)
    {
        _nameOfTask.RemoveAt(index);
        _descriptionOfTheTask.RemoveAt(index);
        _startDate.RemoveAt(index);
        _startDateString.RemoveAt(index);
        _endDate.RemoveAt(index);
        _endDateString.RemoveAt(index);
        _priority.RemoveAt(index);
        _category.RemoveAt(index);
        _taskCompleted.RemoveAt(index);
        _favourite.RemoveAt(index);
        _notification.RemoveAt(index);
    }
}
